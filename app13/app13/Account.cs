﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace app13
{
    public class Account : INotifyPropertyChanged
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
        public string CreatedTime { get { return createdTime; } set { createdTime = value; } }
        private string createdTime;
        public bool Active { get { return active; } }
        private bool active;
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
            active = true;
            createdTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            Buffer.Accounts.Add(this);
        }
        public void Close()
        {
            active = false;
        }

        public void Reopen()
        {
            active = true;
        }

        public override string ToString()
        {
            return this.accountType.ToString() + " Account " + this.currency.ToString() + " " + this.number.ToString();
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

