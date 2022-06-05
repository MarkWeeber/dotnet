using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace WPF1
{
    class TelegramClient
    {
        private MainWindow mainWindow;
        private TelegramBotClient telegramBotClient;
        public ObservableCollection<ChatMessage> chatMessages;
        private string jsonFileName;
        private string token;
        private string saveDirectory;
        private async void MessageListener(object sender, MessageEventArgs e)
        {
            Telegram.Bot.Types.Enums.MessageType type = e.Message.Type;
            string suffix = "";
            switch (type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    suffix = e.Message.Document.FileName;
                    DownloadFile(e.Message.Document.FileId, e.Message.Document.FileName);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    suffix = "photo_" + e.Message.MessageId + ".png";
                    DownloadFile(e.Message.Photo[e.Message.Photo.Length - 1].FileId, suffix);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Voice:
                    suffix = "audio_" + e.Message.MessageId + ".mp3";
                    DownloadFile(e.Message.Voice.FileId, suffix);
                    break;
                default: break;
            }
            // auto answers
            // greeting
            if (e.Message.Text.Trim().ToLower() == "hi")
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Hi, this is telegram bot, you can send me messages, I will save any documment, photo and voice message you send me, if you type /files - I will list all files I saved");
            }
            // checking for /start command
            if (e.Message.Text == "/start")
            {
                await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, $"Greetings {e.Message.Chat.FirstName} to a chat with Luka Siverdi Bot");
            }
            // listing present files in save directory to user
            if (e.Message.Text == "/files")
            {
                if (!Directory.Exists(saveDirectory) || !Directory.EnumerateFileSystemEntries(saveDirectory).Any())
                {
                    await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "No files saved");
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(saveDirectory);
                    FileInfo[] filesInDirectory = di.GetFiles("*.*");
                    if (filesInDirectory.Length > 0)
                    {
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "Here are some files saved in my directory");
                    }
                    else
                    {
                        await telegramBotClient.SendTextMessageAsync(e.Message.Chat.Id, "No files saved");
                    }
                    foreach (var item in filesInDirectory)
                    {
                        string filePath = saveDirectory + item.Name;
                        using (FileStream fs = File.Open(filePath, FileMode.Open))
                        {
                            InputOnlineFile file = new InputOnlineFile(fs);
                            file.FileName = item.Name;
                            await telegramBotClient.SendDocumentAsync(e.Message.Chat.Id, file, "MESSAGE");
                        }
                    }
                }
            }
            if (e.Message.Text == null)
            {
                return;
            }
            mainWindow.Dispatcher.Invoke(() =>
            {
                ChatMessage message = new ChatMessage(DateTime.Now, e.Message.Chat.Id, e.Message.Text, e.Message.Chat.FirstName);
                chatMessages.Add(message);
                SaveToJsonFile(jsonFileName, chatMessages);
            }    
            );
        }

        public TelegramClient(MainWindow mainWindow, string token, string jsonFileName, string saveDirectory)
        {
            this.mainWindow = mainWindow;
            this.token = token;
            this.jsonFileName = jsonFileName;
            this.saveDirectory = saveDirectory;
            string existingJsonFile;
            try
            {
                existingJsonFile = File.ReadAllText(jsonFileName);
                this.chatMessages = new ObservableCollection<ChatMessage>(
                        JsonConvert.DeserializeObject<ObservableCollection<ChatMessage>>(existingJsonFile)
                    );
            }
            catch (Exception)
            {
                this.chatMessages = new ObservableCollection<ChatMessage>();
            }
            telegramBotClient = new TelegramBotClient(this.token);
            telegramBotClient.OnMessage += MessageListener;
            telegramBotClient.StartReceiving();
        }

        public void SendMessage(string text, string id)
        {
            long _id = Convert.ToInt64(id);
            telegramBotClient.SendTextMessageAsync(_id, text);
        }

        private void SaveToJsonFile(string fileName, object data)
        {
            string jsonText = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, jsonText);
        }

        public void StopReceiving()
        {
            telegramBotClient.StopReceiving();
        }

        private async void DownloadFile(string fileId, string fileName)
        {
            var file = await telegramBotClient.GetFileAsync(fileId);
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            FileStream fileStream = new FileStream(saveDirectory + fileName, FileMode.Create);
            await telegramBotClient.DownloadFileAsync(file.FilePath, fileStream);
            fileStream.Close();
            fileStream.Dispose();
        }
    }
}
