using System;
using System.Windows;
using System.Windows.Controls;

namespace app13
{
    public partial class AddNewAccount : Window
    {
        private Customer customer;
        private bool currencyPicked = false;
        private Currency pickedCurrency;
        private CustomerManageWindow customerManageWindow;
        public AddNewAccount(Customer customer, CustomerManageWindow customerManageWindow)
        {
            InitializeComponent();
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
                    new DepositAccount(customer.Id, pickedCurrency);
                }
                else if (ANC_RadioNonDepositTypeChecker.IsChecked == true)
                {
                    new NonDepositAccount(customer.Id, pickedCurrency);
                }
                Buffer.SaveAccounts();
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
