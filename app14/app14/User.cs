using System;
using System.Collections.Generic;

namespace app14
{
    public class User
    {
        static List<string> Names;
        static uint userIndex;
        static User()
        {
            Names = new List<string>();
            userIndex = 0;
        }
        public uint Id { get; }
        public string Name { get; }
        public static void Refresh()
        {
            userIndex = 0;
            Names.Clear();
        }
        public User(string Name)
        {
            Id = ++userIndex;
            if (Name == string.Empty || Names.Contains(Name))
            {
                Name = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{Id.ToString()}";
            }
            Names.Add(Name);
            this.Name = Name;
        }
    }
}
