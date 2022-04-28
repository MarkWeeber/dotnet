using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.InputFiles;

namespace app9
{
    class Program
    {
        private static TelegramBotClient Client;
        private static string SaveDirectory;
        private static string Token;
        static void Main(string[] args)
        {
            SaveDirectory = Directory.GetCurrentDirectory() + @"\save\";
            Token = File.ReadAllText(Directory.GetCurrentDirectory() + @"\telegramToken.txt");
            Client = new TelegramBotClient(Token);
            Client.StartReceiving();
            Client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            Client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            Telegram.Bot.Types.Enums.MessageType type = e.Message.Type;
            string prefix = "";
            string suffix = "";
            switch (type)
            {
                
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    prefix = "wrote:";
                    suffix = e.Message.Text;
                break;
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    prefix = "sent a document, saved with name:";
                    suffix = e.Message.Document.FileName;
                    DownloadFile(e.Message.Document.FileId, e.Message.Document.FileName);
                break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    prefix = "sent a photo, saved with name:";
                    suffix = "photo_" + e.Message.MessageId + ".png";
                    DownloadFile(e.Message.Photo[e.Message.Photo.Length - 1].FileId, suffix);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Voice:
                    prefix = "sent a audio message, saved with name:";
                    suffix = "audio_" + e.Message.MessageId + ".mp3";
                    DownloadFile(e.Message.Voice.FileId, suffix);
                    break;
                default: break;
            }
            string text = $"{DateTime.Now} : {e.Message.Chat.FirstName} {e.Message.Chat.LastName} {prefix} {suffix}";
            Console.WriteLine(text);
            // greeting
            if(e.Message.Text.Trim().ToLower() == "hi")
            {
                await Client.SendTextMessageAsync(e.Message.Chat.Id, "Hi, this is telegram bot, you can send me messages, I will save any documment, photo and voice message you send me, if you type /files - I will list all files I saved");
            }
            // checking for /start command
            if(e.Message.Text == "/start")
            {
                await Client.SendTextMessageAsync(e.Message.Chat.Id, "Already started");
            }
            // listing present files in save directory to user
            if(e.Message.Text == "/files")
            {
                if (!Directory.Exists(SaveDirectory) || !Directory.EnumerateFileSystemEntries(SaveDirectory).Any())
                {
                    await Client.SendTextMessageAsync(e.Message.Chat.Id, "No files saved");
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(SaveDirectory);
                    FileInfo[] filesInDirectory = di.GetFiles("*.*");
                    if(filesInDirectory.Length > 0)
                    {
                        await Client.SendTextMessageAsync(e.Message.Chat.Id, "Here are some files saved in my directory");
                    }
                    else
                    {
                        await Client.SendTextMessageAsync(e.Message.Chat.Id, "No files saved");
                    }
                    foreach (var item in filesInDirectory)
                    {
                        string filePath = SaveDirectory + item.Name;
                        using (FileStream fs = File.Open(filePath, FileMode.Open))
                        {
                            InputOnlineFile file = new InputOnlineFile(fs);
                            file.FileName = item.Name;
                            await Client.SendDocumentAsync(e.Message.Chat.Id, file, "MESSAGE");
                        }
                    }
                }
            }
        }

        private static async void DownloadFile(string fileId, string fileName)
        {
            var file = await Client.GetFileAsync(fileId);
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }
            FileStream fileStream = new FileStream(SaveDirectory + fileName, FileMode.Create);
            await Client.DownloadFileAsync(file.FilePath, fileStream);
            fileStream.Close();
            fileStream.Dispose();
        }
    }
}