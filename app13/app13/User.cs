using System;
using System.Collections.Generic;

namespace app13
{
    public class User
    {
        static List<string> Names;
        static uint userIndex;
        static User()
        {
            Names = new List<string>();
            Refresh();
        }
        public uint Id { get; }
        public string Name { get; }
        public UserRole UserRole { get; }
        public string Credential { get; }
        public static void Refresh()
        {
            userIndex = 0;
            Names.Clear();
            Buffer.Users.Clear();
        }
        public User(string Name, UserRole userRole)
        {
            Id = ++userIndex;
            if (Name == string.Empty || Names.Contains(Name))
            {
                Name = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{Id.ToString()}";
            }
            Names.Add(Name);
            this.Name = Name;
            this.UserRole = userRole;
            Credential = Name + " " + userRole.ToString();
            Buffer.Users.Add(this);
        }

        public string ReadFirstName(Customer customer)
        {
            return customer.FirstName;
        }

        public string ReadLastName(Customer customer)
        {
            return customer.LastName;
        }

        public string ReadMiddleName(Customer customer)
        {
            return customer.MiddleName;
        }

        public void SetPhone(Customer customer, string NewPhone)
        {
            if (NewPhone != String.Empty)
            {
                CustomerChange change = new CustomerChange();
                change.OldPhone = customer.Phone;
                change.LastChangeTime = DateTime.Now;
                change.LastChangeUser = this;
                customer.changelog.Add(change);
                customer.Phone = NewPhone;
            }
        }

        public string ReadPassportNumber(Customer customer)
        {
            string ans = String.Empty;
            if (customer.PassportNumber != String.Empty)
            {
                ans = "********";
            }
            return ans;
        }

        public string ReadPassportSeries(Customer customer)
        {
            string ans = String.Empty;
            if (customer.PassportSeries != String.Empty)
            {
                ans = "********";
            }
            return ans;
        }
    }
}
