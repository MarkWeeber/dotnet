using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Linq;

namespace app13
{
    /// <summary>
    /// Логика взаимодействия для ReplenishAccountWindow.xaml
    /// </summary>
    

    public partial class ReplenishAccountWindow : Window
    {
        private float replenishAmount = -1f;
        private Customer customer;
        private Account account;
        private bool isMainAccount = false;
        private CustomerManageWindow customerManageWindow;

        public ReplenishAccountWindow(Customer customer, Account account, CustomerManageWindow customerManageWindow)
        {
            InitializeComponent();
            this.customer = customer;
            this.account = account;
            this.customerManageWindow = customerManageWindow;
            CheckForMainAccount();
            // map data
            RA_AccountId.Text = account.Id.ToString();
            RA_AccountNumber.Text = account.Number.ToString();
            RA_AccountCurrency.Text = account.Currency.ToString();
            RA_AccountBalance.Text = account.Balance.ToString();

        }

        private void CheckForMainAccount()
        {
            if(Buffer.Customers.Where(item => (item.MainDepositAccountId == account.Id)).Any())
            {
                isMainAccount = true;
            }
            else if(Buffer.Customers.Where(item => (item.MainNonDepositAccountId == account.Id)).Any())
            {
                isMainAccount = true;
            }
        }

        private void RA_TextBoxReplenishAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RA_ButtonReplenish_Click(object sender, RoutedEventArgs e)
        {
            if(float.TryParse(RA_TextBoxReplenishAmount.Text, out replenishAmount))
            {
                if(replenishAmount > 0f)
                {
                    if(isMainAccount)
                    {
                        if(account.AccountType == AccountType.Deposit)
                        {
                            new ReplenishDepositAccount(customer, replenishAmount);
                        }
                        else
                        {
                            new ReplenishNonDepositAccount(customer, replenishAmount);
                        }
                    }
                    else
                    {
                        new TransactionReplenishment(account, replenishAmount, customer);
                    }
                    Buffer.SaveTransactions();
                    Buffer.SaveAccounts();
                    customerManageWindow.RefreshMainAccounts();
                    customerManageWindow.RefreshListViews();
                    this.Close();
                }
            }
        }

        private void RA_ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
