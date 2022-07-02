using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace app13
{
    public abstract class Transaction<Type>
    {
        public Type Source { get { return source; } }
        public string SourceDetails { get { return source.ToString(); } }
        protected Type source;

        public uint Id { get { return id; } }
        protected uint id;
        static uint incrementor;
        public DateTime TransactionTime { get { return transactionTime; } }
        protected DateTime transactionTime;
        public float TransactionAmount { get { return transactionAmount; } }
        protected float transactionAmount;
        public uint UserId { get { return userId; } }
        protected uint userId;
        public uint AccountId { get { return accountId; }  }
        protected uint accountId;
        public uint AccountNumber { get { return accountNumber; } }
        protected uint accountNumber;
        public string TransactionTypeName
        { get
            {
                return transactionType switch
                {
                    TransactionType.BetweenAccounts => "Between accounts",
                    TransactionType.Replenishment => "Replenishment",
                    TransactionType.WithDrawal => "Withdrawal",
                    _ => "",
                };
            }
        }
        public TransactionType TransactionType { get { return transactionType; } }
        protected TransactionType transactionType;
        public static ObservableCollection<Transaction<Type>> Transactions { get {return transactions; } set { if (value == null) { transactions = new ObservableCollection<Transaction<Type>>(); } else { transactions = value; } } }
        protected static ObservableCollection<Transaction<Type>> transactions;
        static Transaction()
        {
            incrementor = 0;
            transactions = new ObservableCollection<Transaction<Type>>();
        }
        public static void Refresh()
        {
            incrementor = 0;
            transactions.Clear();
        }
        public Transaction()
        {
            transactionTime = DateTime.Now;
            userId = Buffer.SelectedUser.Id;
            id = ++incrementor;
        }
        public Transaction<Type> this[int index]
        {
            get { return transactions[index]; }
            set { transactions[index] = value; }
        }
    }
    // parametrized classes
    public class TransactionBetweenAccounts : Transaction<Account>
    {
        public TransactionBetweenAccounts(Account debitAccount, Account creditAccount, float amount)
        {
            transactionAmount = amount;
            accountId = debitAccount.Id;
            accountNumber = debitAccount.Number;
            source = creditAccount;
            debitAccount.Balance += amount;
            creditAccount.Balance -= amount;
            transactionType = TransactionType.BetweenAccounts;
            transactions.Add(this);
        }
    }

    class TransactionReplenishment : Transaction<Customer>
    {
        public TransactionReplenishment(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            accountNumber = MainAccount.Number;
            source = customer;
            MainAccount.Balance += amount;
            transactionType = TransactionType.Replenishment;
            transactions.Add(this);
        }
    }

    class TransactionWithDrawal : Transaction<Customer>
    {
        public TransactionWithDrawal(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            accountNumber = MainAccount.Number;
            source = customer;
            MainAccount.Balance -= amount;
            transactionType = TransactionType.WithDrawal;
            transactions.Add(this);
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
            new TransactionReplenishment(AccountCustomer.MainDepositAccount, amount, customer);
        }
    }
    public class ReplenishNonDepositAccount : IAccountReplenishment<Customer>
    {
        public Customer AccountCustomer { get; set; }
        public ReplenishNonDepositAccount(Customer customer, float amount)
        {
            AccountCustomer = customer;
            new TransactionReplenishment(AccountCustomer.MainNonDepositAccount, amount, customer);
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
            new TransactionBetweenAccounts(BeneficiaryCustomer.MainNonDepositAccount, PayingCustomer.MainNonDepositAccount, amount);
        }
    }
}

