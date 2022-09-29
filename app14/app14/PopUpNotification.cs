using System;

namespace app14
{
    public class PopUpNotification
    {
        public static event Action<string, string> Notify
        {
            add { }
            remove { }
        }
        private static event Action<string, string> notify;
        public PopUpNotification()
        {
            notify?.Invoke("Notifies", "On");
        }
    }
}
