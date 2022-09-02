using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace app14
{
    public static class Buffer
    {
        public static User SelectedUser;
        public static ObservableCollection<Account> Accounts { get => accounts; set => accounts = value ?? new ObservableCollection<Account>(); }
        private static ObservableCollection<Account> accounts;
        public static ObservableCollection<Customer> Customers { get => customers; set => customers = value ?? new ObservableCollection<Customer>(); }
        private static ObservableCollection<Customer> customers;
        public static ObservableCollection<Transaction> Transactions { get => transactions; set => transactions = value ?? new ObservableCollection<Transaction>(); }
        private static ObservableCollection<Transaction> transactions;
        private static Resource customersResource;
        private static Resource accountsResource;
        private static Resource transactionsResource;
        static Buffer()
        {
            Debug.WriteLine("BUFFER INITIALYZE START");
            SelectedUser = null;
            accounts = new ObservableCollection<Account>();
            customers = new ObservableCollection<Customer>();
            transactions = new ObservableCollection<Transaction>();
            customersResource = new Resource("customers.json");
            accountsResource = new Resource("accounts.json");
            transactionsResource = new Resource("transactions.json");
        }

        static public void LoadData()
        {
            // Customers database - retreive from json, or create default values
            Customer.Refresh();
            Customers = customersResource.RetrieveFromJson<ObservableCollection<Customer>>();
            if (!Customers.Any())
            {
                Debug.WriteLine("Customers data not found or corrupted, making default values");
                new Customer("Adamson", "Adam", "Adam Jr", "55-445321", "1160000", "XP");
                new Customer("Brian", "Palma", "De", "55-55123", "1161111", "XP");
                new Customer("Rupert", "Murdoc", "Senior", "55-0101010", "1167701", "DM");
                new Customer("Nixon", "Flow", "Scott", "554-551234", "1160051", "SS");
                new Customer("Jannson", "Greg", "Val", "9-9944-5", "1160016", "DM");
                new Customer("Ruyeen", "Sam", "Gross", "0055855123", "1160051", "SS");
                new Customer("Karvee", "William", "Rum", "00773123", "1160021", "SS");
                new Customer("Samoa", "Josh", "Sent", "55123345", "1160001", "XP");
                customersResource.SaveToJson(customers);
            }
            // Accounts database - retreive from json, or create new accounts
            Account.Refresh();
            Accounts = accountsResource.RetrieveFromJson<ObservableCollection<Account>>();
            if (!Accounts.Any())
            {
                Debug.WriteLine("Accounts data not found");
                for (int i = 0; i < customers.Count; i++)
                {
                    customers[i].MainDepositAccountId = new DepositAccount(customers[i].Id, Currency.RUB).Id;
                    customers[i].MainNonDepositAccountId = new NonDepositAccount(customers[i].Id, Currency.RUB).Id;
                    new DepositAccount(customers[i].Id, Currency.EUR);
                    new DepositAccount(customers[i].Id, Currency.USD);
                    new NonDepositAccount(customers[i].Id, Currency.EUR);
                    new NonDepositAccount(customers[i].Id, Currency.USD);
                }
                accountsResource.SaveToJson(accounts);
                customersResource.SaveToJson(customers);
            }
            // Transactions database - retreive from json
            //Transaction.Refresh();
            Transactions = transactionsResource.RetrieveFromJson<ObservableCollection<Transaction>>();
            if (!Transactions.Any())
            {
                Debug.WriteLine("Transactions data not found");
                new TransactionReplenishment(Buffer.Accounts[0], 100, Buffer.Customers[0]);
            }
        }

        public static void SaveCustomers()
        {
            customersResource.SaveToJson(customers);
        }

        public static void SaveAccounts()
        {
            accountsResource.SaveToJson(accounts);
        }

        public static void SaveTransactions()
        {
            transactionsResource.SaveToJson(transactions);
        }
    }
}
