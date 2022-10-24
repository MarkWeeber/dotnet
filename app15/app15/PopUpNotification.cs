using System.Windows;

namespace app15
{
    public delegate void NotificationDelegate(string Title, string Message);
    public class PopUpNotification
    {
        public event NotificationDelegate Notificate;
        private string title;
        private string message;
        public void Launch()
        {
            Notificate?.Invoke(title, message);
        }
        public void FeedData(string Title, string Message)
        {
            title = Title;
            message = Message;
        }
    }
    public static class PopUp
    {
        public static void MessagePopUp(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
