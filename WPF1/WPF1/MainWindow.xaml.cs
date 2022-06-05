using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPF1
{
    public partial class MainWindow : Window
    {
        TelegramClient client;
        string token;
        string jsonFileName;
        string saveDirectory;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                token = Application.Current.FindResource("TelegramToken").ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Please enter your Telegram Token inside App.xaml before launching \nstring key name : TelegramToken",
                                "Configuration",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                Environment.Exit(0);
            }
            try
            {
                jsonFileName = Application.Current.FindResource("JsonFileName").ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Please designate json file name inside App.xaml before launching \nstring key name : JsonFileName",
                                "Configuration",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                Environment.Exit(0);
            }
            try
            {
                saveDirectory = Application.Current.FindResource("SaveDirectory").ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Please designate save directory inside App.xaml before launching \nstring key name : SaveDirectory",
                                "Configuration",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                Environment.Exit(0);
            }
            saveDirectory = Directory.GetCurrentDirectory().ToString() + $"\\{saveDirectory}\\";
            client = new TelegramClient(this, token, jsonFileName, saveDirectory);
            MessageLogListBox.ItemsSource = client.chatMessages;
            //MessageLogListBox.ScrollIntoView(MessageLogListBox.Items.Count);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            
            if (InputArea.Text == "")
            {
                MessageBox.Show("Please enter your message text");
            }
            else
            {
                if(SendTo.Text == "")
                {
                    MessageBox.Show("Please select whom to send message");
                }
                else
                {
                    client.SendMessage(InputArea.Text, SendTo.Text);
                    InputArea.Text = "";
                }
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputArea.Text = "";
        }

        private void Send_Close(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Open_Save_Folder(object sender, RoutedEventArgs e)
        {
            Process.Start(saveDirectory);
        }

        protected override void OnClosed(EventArgs e)
        {
            client.StopReceiving();
            base.OnClosed(e);
        }
    }
}
