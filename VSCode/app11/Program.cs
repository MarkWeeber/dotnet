using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace app11
{
    class Program
    {
        static void Main(string[] args)
        {
            // try read user database
            Resource userResource = new Resource("users.json");
            List<User> userDatabase = new List<User>();
            userDatabase = userResource.RetrieveFromJson<List<User>>();
            if(userDatabase == null)
            {
                Console.WriteLine("users db file not found, making default values");
                userDatabase = new List<User>();
                userDatabase.Add(new Consultant("Ricardo"));
                userDatabase.Add(new Consultant("Daniel"));
                userDatabase.Add(new Manager("Mike"));
                userDatabase.Add(new Manager("Seaun"));
                userResource.SaveToJson(userDatabase);
            }
            else
            {
                foreach (User item in userDatabase)
                {
                    Console.WriteLine($"{item.Name} {item.userRole}");
                }
            }
            // try read customers database
            Resource customerResource = new Resource("customers.json");
            List<Customer> customerDatabase = new List<Customer>();
            customerDatabase = customerResource.RetrieveFromJson<List<Customer>>();
            if(customerDatabase == null)
            {
                Console.WriteLine("customers db file not found, making default values");
                customerDatabase = new List<Customer>();
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "445321", "3385544", "XP"));
                customerResource.SaveToJson(customerDatabase);
            }
            else
            {
                foreach (Customer item in customerDatabase)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.Phone} {item.PassportSeries} {item.PassportNumber}");
                }
            }
            if(customerDatabase != null && userDatabase != null)
            {
                userDatabase[0].SetPhone(customerDatabase[0], "000000");
                customerResource.SaveToJson(customerDatabase);
            }
        }
    }
}