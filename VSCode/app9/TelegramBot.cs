using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace app9x
{
    public struct TelegramBot
    {
        private string token;
        public TelegramBot(string token)
        {
            this.token = token;
        }
        public void StartBot()
        {
            // webclient
            string startUrl = $@"https://api.telegram.org/bot{token}/";

            WebClient wc = new WebClient() {Encoding = Encoding.UTF8};
            HttpClient hc = new HttpClient();
            int updateId = 0;

            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={updateId}";
                var r = wc.DownloadString(url);
                // breaking down the message json
                var message = JObject.Parse(r)["result"].ToArray();
                foreach (dynamic msg in message)
                {
                    updateId = Convert.ToInt32(msg.update_id) + 1;
                    string userMessage = msg.message.text;
                    string userId = msg.message.from.id;
                    string userFirstName = msg.message.from.first_name;
                    string text = $"{userFirstName} {userId} {userMessage}";
                    Console.WriteLine(text);

                    if (userMessage == "hi")
                    {
                        string responseText = $"Hi, {userFirstName}";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        Console.WriteLine("+");
                        wc.DownloadString(url);
                        Console.WriteLine(text);
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}