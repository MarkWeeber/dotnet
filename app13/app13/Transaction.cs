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
        public static ObservableCollection<Transaction<Type>> Transactions { get; set; }
        static Transaction()
        {
            incrementor = 0;
            Transactions = new ObservableCollection<Transaction<Type>>();
        }
        public static void Refresh()
        {
            incrementor = 0;
            Transactions.Clear();
        }
        public Transaction()
        {
            transactionTime = DateTime.Now;
            userId = Buffer.SelectedUser.Id;
            id = ++incrementor;
        }
        public Transaction<Type> this[int index]
        {
            get { return Transactions[index]; }
            set { Transactions[index] = value; }
        }
    }
    // parametrized classes
    public class TransactionBetweenAccounts : Transaction<Account>
    {
        public TransactionBetweenAccounts(Account debitAccount, Account creditAccount, float amount)
        {
            transactionAmount = amount;
            accountId = debitAccount.Id;
            source = creditAccount;
            debitAccount.Amount += amount;
            creditAccount.Amount -= amount;
            Transactions.Add(this);
        }
    }

    class TransactionReplenishment : Transaction<Customer>
    {
        public TransactionReplenishment(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            source = customer;
            MainAccount.Amount += amount;
            Transactions.Add(this);
        }
    }

    class TransactionWithDrawal : Transaction<Customer>
    {
        public TransactionWithDrawal(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            source = customer;
            MainAccount.Amount -= amount;
            Transactions.Add(this);
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

