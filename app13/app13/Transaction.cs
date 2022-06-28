using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace app13
{
    public class Transaction<Type>
    {
        public uint Id { get; }
        static uint incrementor;
        public DateTime TransactionTime { get; set; }
        public float TransactionAmount { get; set; }
        public uint UserId { get; }
        public Account MainAccount { get; set; }
        public uint AccountId { get; set; }
        public Type source { get; set; }
        static Transaction()
        {
            items = new List<Transaction<Type>>();
            incrementor = 0;
        }
        public static void Refresh()
        {
            incrementor = 0;
        }
        public Transaction()
        {
            TransactionTime = DateTime.Now;
            UserId = Buffer.SelectedUser.Id;
            Id = ++incrementor;
        }
        public static List<Transaction<Type>> items;
        public Transaction<Type> this [int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

    }
    public class TransactionBetweenAccounts : Transaction<Account>
    {
        public TransactionBetweenAccounts(Account debitAccount, Account creditAccount, float amount)
        {
            TransactionAmount = amount;
            MainAccount = debitAccount;
            AccountId = debitAccount.Id;
            source = debitAccount;
            debitAccount.Amount += amount;
            creditAccount.Amount -= amount;
            items.Add(this);
            //Buffer.Transactions.Add(this);
        }
    }

    class TransactionReplenishment : Transaction<Customer>
    {
        public TransactionReplenishment(Account MainAccount, float amount, Customer customer)
        {
            TransactionAmount = amount;
            this.MainAccount = MainAccount;
            source = customer;
            MainAccount.Amount += amount;
            items.Add(this);
        }
    }

    class TransactionWithDrawal : Transaction<Customer>
    {
        public TransactionWithDrawal(Account MainAccount, float amount, Customer customer)
        {
            TransactionAmount = amount;
            this.MainAccount = MainAccount;
            source = customer;
            MainAccount.Amount -= amount;
            items.Add(this);
        }
    }
}

