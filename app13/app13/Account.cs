using System;
using System.Collections.Generic;
using System.Text;

namespace app13
{
    public abstract class Account
    {
        public static uint incrementor;
        public uint Id { get; }
        public uint Number { get; }
        public float Amount { get; set; }
        public Currency Currency { get; }
        public Customer Customer { get; }
        public uint CustomerId { get; }
        public AccountType AccountType { get; }
        public uint UserId { get; }
        public DateTime CreatedTime { get; }
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
            Id = ++incrementor;
            Number = 118000 + Id;
            Customer = customer;
            CustomerId = customer.Id;
            UserId = Buffer.SelectedUser.Id;
            AccountType = accountType;
            Currency = currency;
            CreatedTime = DateTime.Now;
        }
    }

    public abstract class AccountAction<Type>
    {
        
    }

    public class OpenDeposit : AccountAction<Customer>
    {
        // TO DO Buffer.Accounts.Add(this);
    }

    public class CloseDeposit : AccountAction<Customer>
    {

    }

    public class OpenNonDeposit : AccountAction<Customer>
    {

    }

    public class CloseNonDeposit : AccountAction<Customer>
    {

    }
}

