using System;
using System.Collections.Generic;

namespace app12
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
        public string Name { get; }
        public UserRole UserRole { get; }
        public string Credential { get; }
        public static void Refresh()
        {
            Names.Clear();
            userIndex = 0;
        }
        public User(string Name, UserRole userRole) // consultant is by default
        {
            userIndex++;
            if (Name == string.Empty || Names.Contains(Name)) // searching through names database
            {
                Name = $"{Guid.NewGuid().ToString().Substring(0, 5)}_{userIndex.ToString()}";
            }
            Names.Add(Name);
            this.Name = Name;
            this.UserRole = userRole;
            Credential = Name + " " + userRole.ToString();
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
