using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using System.Collections.ObjectModel;



namespace WPF1
{
    class TelegramClient
    {
        private MainWindow mainWindow;
        private TelegramBotClient telegramBotClient;
        public ObservableCollection<ChatMessage> chatMessages;
        private void MessageListener(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == null)
            {
                return;
            }
            mainWindow.Dispatcher.Invoke(() =>
            {
                ChatMessage message = new ChatMessage(DateTime.Now, e.Message.Chat.Id, e.Message.Text, e.Message.Chat.FirstName);
                chatMessages.Add(message);
            }    
            );
        }

        public TelegramClient(MainWindow mainWindow)
        {
            this.chatMessages = new ObservableCollection<ChatMessage>();
            this.mainWindow = mainWindow;
            telegramBotClient = new TelegramBotClient(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Tokens\TelegramToken.txt"));
            telegramBotClient.OnMessage += MessageListener;
            telegramBotClient.StartReceiving();
        }

        public void SendMessage(string text, string id)
        {
            long _id = Convert.ToInt64(id);
            telegramBotClient.SendTextMessageAsync(_id, text);
        }
    }
}
