using System;
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

namespace WPF1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TelegramClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new TelegramClient(this);
            MessageLogListBox.ItemsSource = client.chatMessages;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            
            if (InputArea.Text == "")
            {
                MessageBox.Show($"Please enter your message text");
            }
            else
            {
                if(SendTo.Text == "")
                {
                    MessageBox.Show($"Please select whom to send message");
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
    }
}
