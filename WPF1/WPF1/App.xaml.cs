using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace WPF1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string Token;
        protected override void OnStartup(StartupEventArgs e)
        {
            Token = File.ReadAllText(Directory.GetCurrentDirectory() + @"\Tokens\TelegramToken.txt");
            MessageBox.Show("Hello World!" + "\n" + "Welcome to Telegram Bot" + "\n" + Token);
        }
    }
}
