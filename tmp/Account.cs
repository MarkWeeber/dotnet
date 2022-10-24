using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace app15
{
    public enum AccountState
    {
        Opened, Activated, Deactivated
    }
    public struct AccountStateLog
    {
        public static uint incrementor;
        public uint Id { get; }
        public string LastChangeUserName { get; set; }
        public string LastChangeTime { get; set; }
        public uint CustomerId { get; set; }
        public uint AccountId { get; set; }
        public Currency Currency { get; set; }
        public AccountState AccountState { get; set; }

        static AccountStateLog()
        {
            incrementor = 0;
        }
        public AccountStateLog(Account account, AccountState accountState)
        {
            Id = ++incrementor;
            AccountId = account.Id;
            Currency = account.Currency;
            CustomerId = account.CustomerId;
            AccountState = accountState;
            LastChangeTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm t");
            LastChangeUserName = Buffer.SelectedUser.Name;
            //PopUpNotification.Notify += NotifyOnStateChange;
            //var x = new PopUpNotification();
            //MessageBox.Show("Account changed", "Caption", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void NotifyOnStateChange(string messageTitle, string messageDetails)
        {
            Debug.WriteLine($"Account creation {messageTitle} {messageDetails} the account {AccountId} has set it's state to {AccountState}");
        }
    }

    public class Account : INotifyPropertyChanged
    {   
        public static uint incrementor;
        public uint Id { get{ return id; } }
        private uint id;
        public uint Number { get {return number; } }
        private uint number;
        public float Balance { get { return balance; } set { SetField(ref balance, value, "Balance"); } }
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
        public bool Active { get { return active; } set { SetField(ref active, value, "Active"); } }
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

