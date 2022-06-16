using System;
using System.Linq;
using System.Collections.Generic;

namespace app11
{
    public class User
    {
        // static data
        static List<string> Names;
        static uint userIndex;
        static User()
        {
            Names = new List<string>();
            userIndex = 0;
        }
        // custom data
        public string Name;
        public UserRole userRole;
        public User(string Name, UserRole userRole = UserRole.Consultant) // consultant is by default
        {
            userIndex++;
            if (Name == String.Empty || this.Names.Contains(Name)) // searching through names database
            {
                Name = $"{Guid.NewGuid().ToString().SubString(0, 5)}_{userIndex.ToString()}";
            }
            this.Names.Add(Name);
            this.Name = Name;
            this.userRole = userRole;
        }
    }
}
