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

namespace app13
{
    /// <summary>
    /// Логика взаимодействия для CustomerManageWindow.xaml
    /// </summary>
    public partial class CustomerManageWindow : Window
    {
        private Customer selectedCustomer;
        public CustomerManageWindow(Customer customer)
        {
            InitializeComponent();
            selectedCustomer = customer;
            // map data
            CustomerViewTextBlockFirstName.Text = selectedCustomer.FirstName;
            CustomerViewTextBlockLastName.Text = selectedCustomer.LastName;
            CustomerViewTextBlockMiddleName.Text = selectedCustomer.MiddleName;
            CustomerViewTextBlockPhone.Text = selectedCustomer.Phone;
            CustomerViewTextBlockPassportNumber.Text = selectedCustomer.PassportNumber;
            CustomerViewTextBlockPassportSeries.Text = selectedCustomer.PassportSeries;
            CustomerViewTextBlockRegistrationDate.Text = selectedCustomer.CreatedTime.ToString();
            CV_MainDepositAccountNumber.Text = selectedCustomer.MainDepositAccount.Number.ToString();
            CV_MainDepositAccountBalance.Text = selectedCustomer.MainDepositAccount.Balance.ToString();
            CV_MainDepositAccountCurrency.Text = selectedCustomer.MainDepositAccount.Currency.ToString();
            CV_MainNonDepositAccountNumber.Text = selectedCustomer.MainNonDepositAccount.Number.ToString();
            CV_MainNonDepositAccountBalance.Text = selectedCustomer.MainNonDepositAccount.Balance.ToString();
            CV_MainNonDepositAccountCurrency.Text = selectedCustomer.MainNonDepositAccount.Currency.ToString();

        }
    }
}
