using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CommercialBankLibrary_16;

namespace app16
{
    public partial class TransferBetweenAccountsWindow : Window
    {
        private float transferAmount = -1f;
        private Account sourceAccount;
        private Account beneficiaryAccount;
        private Customer sourceCustomer;
        private Customer beneficiaryCustomer;
        private CustomerManageWindow customerManageWindow;
        public TransferBetweenAccountsWindow(Account account, CustomerManageWindow customerManageWindow)
        {
            InitializeComponent();
            this.sourceAccount = account;
            this.customerManageWindow = customerManageWindow;
            // finding source customer object
            sourceCustomer = Buffer.Customers.Where(item => item.Id == sourceAccount.CustomerId).ToList()[0];
            // maping data
            TBA_TextBlockSourceAccountHolderName.Text = sourceCustomer.ToString();
            TBA_TextBlockSourceAccountId.Text = sourceAccount.Id.ToString();
            TBA_TextBlockSourceAccountNumber.Text = sourceAccount.Number.ToString();
            TBA_TextBlockSourceAccountType.Text = sourceAccount.AccountType.ToString();
            TBA_TextBlockSourceAccountCurrency.Text = sourceAccount.Currency.ToString();
            TBA_TextBlockSourceAccountBalance.Text = sourceAccount.Balance.ToString();
            TBA_TextBlockMaxAllowedAmount.Text = "Max Allowed: " + sourceAccount.Balance.ToString();
            // maping combobox
            TBA_ComboboxPickDestinationAccountHolderName.ItemsSource = Buffer.Customers.Where(item => item.Id != sourceCustomer.Id).ToList();
        }

        private void TBA_ComboboxPickDestinationAccountHolderName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficiaryCustomer = TBA_ComboboxPickDestinationAccountHolderName.SelectedItem as Customer;
            TBA_ListViewDestinationAccountPicker.ItemsSource = new ObservableCollection<Account>(Buffer.Accounts.Where
                (
                    item =>
                    (item.CustomerId == beneficiaryCustomer.Id) &&
                    (item.CustomerId != sourceCustomer.Id) &&
                    (item.Active == true)
                )
                );
            beneficiaryAccount = null;
            TBA_ListViewDestinationAccountPicker.UnselectAll();
        }

        private void TBA_PreviewInputAmountText(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TBA_ListViewDestinationAccountPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficiaryAccount = TBA_ListViewDestinationAccountPicker.SelectedItem as Account;
        }

        private void TBA_ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TBA_ButtonSendTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(TBA_TextBoxInputAmount.Text, out transferAmount))
            {
                if (transferAmount > 0f)
                {
                    try
                    {
                        new TransactionBetweenAccounts(beneficiaryAccount, sourceAccount, transferAmount);
                        Buffer.SaveTransactions();
                        Buffer.SaveAccounts();
                        // Calling delegate example
                        PopUpNotification transferNotification = new PopUpNotification();
                        transferNotification.FeedData("Transfer between accounts", $"A {transferAmount} {sourceAccount.Currency} was sent from Account #{sourceAccount.Number} to Account #{beneficiaryAccount.Number} \ntransfer done by user: {Buffer.SelectedUser.Name}");
                        transferNotification.Notificate += PopUp.MessagePopUp;
                        transferNotification.Launch();
                        // Calling delegate example end
                        customerManageWindow.RefreshMainAccounts();
                        customerManageWindow.RefreshListViews();
                        this.Close();
                    }
                    catch (OutOfBalanceException exception)
                    {
                        MessageBox.Show(this, $"Accounnt {exception.SourceAccount.Number} has insufficient funds", "Out of balance", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
