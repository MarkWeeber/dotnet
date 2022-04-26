using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace app9
{
    class Program
    {
        private static TelegramBotClient client;
        private static string saveDirectory;
        private static string token;
        static void Main(string[] args)
        {
            saveDirectory = Directory.GetCurrentDirectory() + @"\save\";
            token = File.ReadAllText(Directory.GetCurrentDirectory() + @"\telegramToken.txt");
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
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
            // checking for /start command
            if (e.Message.Text == "/start")
            {
                string response = "Already started";
                await client.SendTextMessageAsync(e.Message.Chat.Id, response);
            }
        }

        private static async void DownloadFile(string fileId, string fileName)
        {
            var file = await client.GetFileAsync(fileId);
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            FileStream fileStream = new FileStream(saveDirectory + fileName, FileMode.Create);
            await client.DownloadFileAsync(file.FilePath, fileStream);
            fileStream.Close();
            fileStream.Dispose();
        }

    }
}