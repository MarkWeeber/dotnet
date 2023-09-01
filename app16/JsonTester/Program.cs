using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace JsonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string json = @"{ 'xNAME': 'AdminX' }{ 'Xname': 'Publisher' }";

            IList<Role> roles = new List<Role>();

            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            reader.SupportMultipleContent = true;

            while (true)
            {
                if (!reader.Read())
                {
                    break;
                }

                JsonSerializer serializer = new JsonSerializer();
                Role role = serializer.Deserialize<Role>(reader);

                roles.Add(role);
            }

            foreach (Role role in roles)
            {
                Console.WriteLine(role.XName);
            }
        }
    }

    public class Role
    {
        public string XName { get; set; }
    }


}
