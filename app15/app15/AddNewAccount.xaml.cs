using System;
using System.Windows;
using System.Windows.Controls;

namespace app15
{
    public partial class AddNewAccount : Window
    {
        private Customer customer;
        private bool currencyPicked = false;
        private Currency pickedCurrency;
        private CustomerManageWindow customerManageWindow;
        private Account newAccout;
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
                    newAccout = new DepositAccount(customer.Id, pickedCurrency);
                }
                else if (ANC_RadioNonDepositTypeChecker.IsChecked == true)
                {
                    newAccout = new NonDepositAccount(customer.Id, pickedCurrency);
                }
                Buffer.AccountsStatesLog.Add(new AccountStateLog(newAccout, AccountState.Opened));
                Buffer.SaveAccountsStatesLog();
                Buffer.SaveAccounts();
                // Calling delegate example
                PopUpNotification newAccountNotification = new PopUpNotification();
                newAccountNotification.FeedData("New account", $"A new Account with number #{newAccout.Number} was created by user: {Buffer.SelectedUser.Name}");
                newAccountNotification.Notificate += PopUp.MessagePopUp;
                newAccountNotification.Launch();
                // Calling delegate example end
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
