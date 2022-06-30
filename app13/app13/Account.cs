using System;
using System.Collections.Generic;
using System.Text;

namespace app13
{
    public abstract class Account
    {
        public static uint incrementor;
        public uint Id { get{ return id; } }
        private uint id;
        public uint Number { get {return number; } }
        private uint number;
        public float Amount { get { return amount; } set { amount = value; } }
        private float amount;
        public Currency Currency { get { return currency; } }
        private Currency currency;
        public uint CustomerId { get { return customerId; } }
        private uint customerId;
        public AccountType AccountType { get { return accountType; } }
        private AccountType accountType;
        public uint UserId { get { return userId; } }
        private uint userId;
        public DateTime CreatedTime { get { return createdTime; } }
        private DateTime createdTime;
        public bool Open { get { return open; } }
        private bool open;
        static Account()
        {
            incrementor = 0;
        }
        public static void Refresh()
        {
            incrementor = 0;
            Buffer.Accounts.Clear();
        }
        public Account(Customer customer, AccountType accountType, Currency currency)
        {
            id = ++incrementor;
            number = 118000 + id;
            customerId = customer.Id;
            userId = Buffer.SelectedUser.Id;
            this.accountType = accountType;
            this.currency = currency;
            open = true;
            createdTime = DateTime.Now;
            Buffer.Accounts.Add(this);
        }
        public void Close()
        {
            open = false;
        }

        public void Reopen()
        {
            open = true;
        }
    }

    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, Currency currency) : base (customer, AccountType.Deposit, currency)
        {

        }
    }
    public class NonDepositAccount : Account
    {
        public NonDepositAccount(Customer customer, Currency currency) : base(customer, AccountType.NonDeposit, currency)
        {

        }
    }
}

