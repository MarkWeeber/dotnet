using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;

namespace app13
{
    interface ITransaction<out Type>
    {
        Type Source { get; }
    }

    public abstract class Transaction<Type> : ITransaction<Type>
    {
        public Type Source { get; set; }

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
        public static List<Transaction<Type>> Transactions { get; set; }
        static Transaction()
        {
            incrementor = 0;
            Transactions = new List<Transaction<Type>>();
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

    public class TransactionBetweenAccounts : Transaction<Account>
    {
        public TransactionBetweenAccounts(Account debitAccount, Account creditAccount, float amount)
        {
            transactionAmount = amount;
            accountId = debitAccount.Id;
            Source = debitAccount;
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
            Source = customer;
            MainAccount.Amount += amount;
            Transactions.Add(this);
        }
    }

    class TransactionWithDrawal : Transaction<Customer>
    {
        public TransactionWithDrawal(Account MainAccount, float amount, Customer customer)
        {
            transactionAmount = amount;
            Source = customer;
            MainAccount.Amount -= amount;
            Transactions.Add(this);
        }
    }
}

