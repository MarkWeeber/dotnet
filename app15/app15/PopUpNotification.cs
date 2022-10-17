using System;

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
}
