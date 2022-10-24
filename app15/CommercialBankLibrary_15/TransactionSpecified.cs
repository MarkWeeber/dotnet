using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CommercialBankLibrary_15
{
    public class Transaction : INotifyPropertyChanged
    {
        public uint Id { get { return id; } set { id = value; } }
        protected uint id;
        public string SourceDetails { get; set; }
        private static uint incrementor;
        public string TransactionTime { get { return transactionTime; } set { transactionTime = value; } }
        protected string transactionTime;
        public float TransactionAmount { get { return transactionAmount; } set { transactionAmount = value; } }
        protected float transactionAmount;
        public uint UserId { get { return userId; } set { userId = value; } }
        protected uint userId;
        public uint AccountId { get { return accountId; } set { accountId = value; } }
        protected uint accountId;
        public uint AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        protected uint accountNumber;
        public string TransactionTypeName
        { get
            {
                    switch (transactionType)
                {
                    case TransactionType.Default:
                        return "Default Empty";
                    case TransactionType.BetweenAccounts:
                        return "Between accounts";
                    case TransactionType.Replenishment:
                        return "Replenishment";
                    case TransactionType.WithDrawal:
                        return "Withdrawal";
                    default:
                        return "";
                }
            }
            set
            {
                ;
            }
        }
        public TransactionType TransactionType { get { return transactionType; } set { transactionType = value; } }
        protected TransactionType transactionType;
        static Transaction()
        {
            incrementor = 0;
        }
        public static void Refresh()
        {
            incrementor = 0;
            Buffer.Transactions.Clear();
        }
        public Transaction()
        {
            transactionTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            userId = Buffer.SelectedUser.Id;
            id = ++incrementor;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class TransactionSpecified<T> : Transaction
    {
        protected T source;
        
    }
    // parametrized classes
    public class TransactionBetweenAccounts : TransactionSpecified<Account>
    {
        public TransactionBetweenAccounts(Account debitAccount, Account creditAccount, float amount)
        {
            transactionAmount = amount;
            accountId = debitAccount.Id;
            accountNumber = debitAccount.Number;
            source = creditAccount;
            SourceDetails = source.ToString();
            transactionType = TransactionType.BetweenAccounts;
            if (creditAccount.Balance >= amount)
            {
                debitAccount.Balance += amount;
                creditAccount.Balance -= amount;
                Buffer.Transactions.Add((Transaction)this);
            }
            else
            {
                throw new OutOfBalanceException(creditAccount);
            }
        }
    }

    public class TransactionReplenishment : TransactionSpecified<Customer>
    {
        public TransactionReplenishment(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            accountNumber = MainAccount.Number;
            source = customer;
            SourceDetails = source.ToString();
            MainAccount.Balance += amount;
            transactionType = TransactionType.Replenishment;
            Buffer.Transactions.Add((Transaction)this);
        }
    }

    class TransactionWithDrawal : TransactionSpecified<Customer>
    {
        public TransactionWithDrawal(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            accountNumber = MainAccount.Number;
            source = customer;
            SourceDetails = source.ToString();
            MainAccount.Balance -= amount;
            transactionType = TransactionType.WithDrawal;
            Buffer.Transactions.Add((Transaction)this);
        }
    }
    // covariant intefrace
    interface IAccountReplenishment<out T> where T : Customer
    {
        T AccountCustomer { get; }
    }

    public class ReplenishDepositAccount : IAccountReplenishment<Customer>
    {
        public Customer AccountCustomer { get; set; }
        public ReplenishDepositAccount(Customer customer, float amount)
        {
            AccountCustomer = customer;
            Account depositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => item.Id == customer.MainDepositAccountId))[0];
            new TransactionReplenishment(depositAccount, amount, customer);
        }
    }
    public class ReplenishNonDepositAccount : IAccountReplenishment<Customer>
    {
        public Customer AccountCustomer { get; set; }
        public ReplenishNonDepositAccount(Customer customer, float amount)
        {
            AccountCustomer = customer;
            Account nonDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => item.Id == customer.MainNonDepositAccountId))[0];
            new TransactionReplenishment(nonDepositAccount, amount, customer);
        }
    }
    // contravariant interface
    interface IAccountTransfer<in T, in K> where T : Customer where K : Customer
    {
        T BeneficiaryCustomer { set; }
        T PayingCustomer { set; }
    }

    public class TransferBetweenCustomers : IAccountTransfer<Customer, Customer>
    {
        public Customer BeneficiaryCustomer { get; set; }
        public Customer PayingCustomer { get; set; }
        public TransferBetweenCustomers(Customer beneficiary, Customer payingCustomer, float amount)
        {
            BeneficiaryCustomer = beneficiary;
            PayingCustomer = payingCustomer;
            Account beneficiaryNonDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => item.Id == beneficiary.MainNonDepositAccountId))[0];
            Account payingNonDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => item.Id == payingCustomer.MainNonDepositAccountId))[0];
            new TransactionBetweenAccounts(beneficiaryNonDepositAccount, payingNonDepositAccount, amount);
        }
    }
}

