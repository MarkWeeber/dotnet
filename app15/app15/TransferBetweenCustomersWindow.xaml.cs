using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace app15
{
    /// <summary>
    /// Логика взаимодействия для TransferBetweenCustomersWindow.xaml
    /// </summary>
    public partial class TransferBetweenCustomersWindow : Window
    {
        private float transferAmount = -1f;
        private Customer sourceCustomer;
        private Customer beneficiaryCustomer;
        private Account sourceAccount;
        private Account beneficiaryAccount;
        public TransferBetweenCustomersWindow()
        {
            InitializeComponent();
            // maping main combobox
            TBC_ComboBoxSourceCustomer.ItemsSource = Buffer.Customers;
            TBC_ComboBoxBeneficiaryCustomer.IsEnabled = false;
        }

        private void TBC_ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TBC_ButtonSendTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(TBC_TextBoxInputAmount.Text, out transferAmount))
            {
                if (transferAmount > 0f)
                {
                    try
                    {
                        new TransferBetweenCustomers(beneficiaryCustomer, sourceCustomer, transferAmount);
                        Buffer.SaveTransactions();
                        Buffer.SaveAccounts();
                        // Calling delegate example
                        PopUpNotification transferNotification = new PopUpNotification();
                        transferNotification.FeedData("Transfer between accounts", $"A {transferAmount} {sourceAccount.Currency} was sent from Account #{sourceAccount.Number} to Account #{beneficiaryAccount.Number} \ntransfer done by user: {Buffer.SelectedUser.Name}");
                        transferNotification.Notificate += PopUp.MessagePopUp;
                        transferNotification.Launch();
                        // Calling delegate example end
                        this.Close();

                    }
                    catch (OutOfBalanceException exception)
                    {
                        MessageBox.Show(this, $"Accounnt {exception.SourceAccount.Number} has insufficient funds", "Out of balance", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }

        private void TBC_TextBoxInputAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TBC_ComboBoxSourceCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sourceCustomer = TBC_ComboBoxSourceCustomer.SelectedItem as Customer;
            sourceAccount = Buffer.Accounts.Where(item => item.Id == sourceCustomer.MainNonDepositAccountId).ToList()[0];
            UpdateSourceAccountIndicators();
            TBC_ComboBoxBeneficiaryCustomer.IsEnabled = true;
            TBC_ComboBoxBeneficiaryCustomer.ItemsSource = Buffer.Customers.Where(item => item.Id != sourceCustomer.Id);
            //TBC_ComboBoxBeneficiaryCustomer.SelectedItem = null;
            
        }

        private void UpdateSourceAccountIndicators()
        {
            TBC_TextBlockSourceAccoundId.Text = sourceAccount.Id.ToString();
            TBC_TextBlockSourceAccoundNumber.Text = sourceAccount.Number.ToString();
            TBC_TextBlockSourceAccoundCurrency.Text = sourceAccount.Currency.ToString();
            TBC_TextBlockSourceAccoundBalance.Text = sourceAccount.Balance.ToString();
            TBC_TextBlockMaxAllowedAmount.Text = "Max Allowed: " + sourceAccount.Balance.ToString();
        }

        private void TBC_ComboBoxBeneficiaryCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            beneficiaryCustomer = TBC_ComboBoxBeneficiaryCustomer.SelectedItem as Customer;
            if(beneficiaryCustomer != null)
            {
                beneficiaryAccount = Buffer.Accounts.Where(item => item.Id == beneficiaryCustomer.MainNonDepositAccountId).ToList()[0];
                UpdateBeneficiaryAccountIndicators();
            }
            else
            {
                ClearBeneficiaryInfo();
            }
        }

        private void UpdateBeneficiaryAccountIndicators()
        {
            TBC_TextBlockBeneficiaryAccoundId.Text = beneficiaryAccount.Id.ToString();
            TBC_TextBlockBeneficiaryAccoundNumber.Text = beneficiaryAccount.Number.ToString();
            TBC_TextBlockBeneficiaryAccoundCurrency.Text = beneficiaryAccount.Currency.ToString();
            TBC_TextBlockBeneficiaryAccoundBalance.Text = beneficiaryAccount.Balance.ToString();
        }

        private void ClearBeneficiaryInfo()
        {
            TBC_TextBlockBeneficiaryAccoundId.Text = "XXXXXX";
            TBC_TextBlockBeneficiaryAccoundNumber.Text = "XXXXXX";
            TBC_TextBlockBeneficiaryAccoundCurrency.Text = "XXXXXX";
            TBC_TextBlockBeneficiaryAccoundBalance.Text = "XXXXXX";
        }
    }
}
