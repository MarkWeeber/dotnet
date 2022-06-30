using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace app13
{
    public static class Buffer
    {
        public static User SelectedUser;
        public static ObservableCollection<Account> Accounts { get => accounts; set => accounts = value ?? new ObservableCollection<Account>(); }
        private static ObservableCollection<Account> accounts;
        public static ObservableCollection<Customer> Customers { get => customers; set => customers = value ?? new ObservableCollection<Customer>(); }
        private static ObservableCollection<Customer> customers;
        static Buffer()
        {
            SelectedUser = null;
            accounts = new ObservableCollection<Account>();
            customers = new ObservableCollection<Customer>();
            Debug.WriteLine("BUFFER INITIALIZED");
        }
        public static void Refresh()
        {
            SelectedUser = null;
            Accounts.Clear();
            Account.Refresh();
            Customers.Clear();
            Customer.Refresh();
            Transaction<Type>.Refresh();
        }
    }
}
