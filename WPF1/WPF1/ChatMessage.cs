using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF1
{
    struct ChatMessage
    {
        public DateTime Time { get; set; }
        public long id { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
        public ChatMessage(DateTime Time, long id, string Message, string SenderName)
        {
            this.Time = Time;
            this.id = id;
            this.Message = Message;
            this.SenderName = SenderName;
        }

    }
}
