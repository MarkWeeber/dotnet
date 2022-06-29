using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace app13
{
    public static class Buffer
    {
        public static User SelectedUser { get; set; }
        public static List<Account> Accounts { get; set; }
        public static List<User> Users { get; set; }
        public static ObservableCollection<Customer> Customers { get; set; }
        static Buffer()
        {
            SelectedUser = null;
            Accounts = new List<Account>();
            Users = new List<User>();
            Customers = new ObservableCollection<Customer>();
        }
        public static void Refresh()
        {
            SelectedUser = null;
            Accounts.Clear();
            Account.Refresh();
            Users.Clear();
            User.Refresh();
            Customers.Clear();
            Customer.Refresh();
            Transaction<Type>.Refresh();
        }
    }
}
