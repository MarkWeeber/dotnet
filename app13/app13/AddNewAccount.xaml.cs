using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class AddNewAccount : Window
    {
        private Resource accountsResource;
        private Customer customer;
        private Account newAccount;
        private bool currencyPicked = false;
        private Currency pickedCurrency;
        private CustomerManageWindow customerManageWindow;
        public AddNewAccount(Resource accountsResource, Customer customer, CustomerManageWindow customerManageWindow)
        {
            InitializeComponent();
            this.accountsResource = accountsResource;
            this.customer = customer;
            this.customerManageWindow = customerManageWindow;
            ANC_ComboBoxCurrencyPicker.ItemsSource = Enum.GetValues((typeof(Currency)));
        }

        private void ANC_ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ANC_ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (currencyPicked)
            {
                if (ANC_RadioDepositTypeChecker.IsChecked == true)
                {
                    newAccount = new DepositAccount(customer.Id, pickedCurrency);
                }
                else if (ANC_RadioNonDepositTypeChecker.IsChecked == true)
                {
                    newAccount = new NonDepositAccount(customer.Id, pickedCurrency);
                }
                accountsResource.SaveToJson(Buffer.Accounts);
                customerManageWindow.RefreshListViews();
                this.Close();
            }
        }

        private void ANC_ComboBoxCurrencyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pickedCurrency = (Currency)ANC_ComboBoxCurrencyPicker.SelectedItem;
            currencyPicked = true;
        }
    }
}
