﻿using System;
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
        public float Balance { get { return balance; } set { balance = value; } }
        private float balance;
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
        public Account(uint customerId, AccountType accountType, Currency currency)
        {
            id = ++incrementor;
            number = 118000 + id;
            this.customerId = customerId;
            userId = Buffer.SelectedUser.Id;
            this.accountType = accountType;
            this.currency = currency;
            balance = 0;
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

        public override string ToString()
        {
            return this.accountType.ToString() + " Account " + this.currency.ToString() + " " + this.number.ToString();
        }
    }

    public class DepositAccount : Account
    {
        public DepositAccount(uint customerId, Currency currency) : base (customerId, AccountType.Deposit, currency)
        {

        }
    }
    public class NonDepositAccount : Account
    {
        public NonDepositAccount(uint customerId, Currency currency) : base(customerId, AccountType.NonDeposit, currency)
        {

        }
    }
}

