using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace app15
{
    public partial class CustomerManageWindow : Window
    {
        public Customer selectedCustomer;
        private Account selectedOtherActiveAccount;
        private Account selectedOtherInactiveAccount;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private Account mainDepositAccount;
        private Account mainNonDepositAccount;
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
            CustomerViewTextBlockRegistrationDate.Text = selectedCustomer.CreatedTime;
            RefreshMainAccounts();
            RefreshListViews();
        }

        private void CV_ListViewOtherAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOtherActiveAccount = CV_ListViewOtherAccounts.SelectedItem as Account;
            CV_ButtonReplenishAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
            CV_ButtonTransferFromAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
            CV_ButtonDeactivateAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
        }

        private void CV_ListViewOtherAccountsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, CV_ListViewOtherAccounts);
        }

        private void ManageColumnsSorting(object sender, ListView listView)
        {
            if (listView != null)
            {
                GridViewColumnHeader column = sender as GridViewColumnHeader;
                string sortBy = column.Tag.ToString();
                if (listViewSortCol != null)
                {
                    AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                    listView.Items.SortDescriptions.Clear();
                }

                ListSortDirection newDir = ListSortDirection.Ascending;
                if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                    newDir = ListSortDirection.Descending;

                listViewSortCol = column;
                listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
                AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
                listView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
            }
        }

        private void CV_ButtonAddNewAccount_Click(object sender, RoutedEventArgs e)
        {
            AddNewAccount addNewAccount = new AddNewAccount(selectedCustomer, this);
            addNewAccount.ShowDialog();
        }

        public void RefreshMainAccounts()
        {
            mainDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => (item.Id == selectedCustomer.MainDepositAccountId)))[0];
            mainNonDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => (item.Id == selectedCustomer.MainNonDepositAccountId)))[0];
            CV_MainDepositAccountId.Text = mainDepositAccount.Id.ToString();
            CV_MainDepositAccountNumber.Text = mainDepositAccount.Number.ToString();
            CV_MainDepositAccountBalance.Text = mainDepositAccount.Balance.ToString();
            CV_MainDepositAccountCurrency.Text = mainDepositAccount.Currency.ToString();
            CV_MainNonDepositAccountId.Text = mainNonDepositAccount.Id.ToString();
            CV_MainNonDepositAccountNumber.Text = mainNonDepositAccount.Number.ToString();
            CV_MainNonDepositAccountBalance.Text = mainNonDepositAccount.Balance.ToString();
            CV_MainNonDepositAccountCurrency.Text = mainNonDepositAccount.Currency.ToString();
        }

        public void RefreshListViews()
        {
            CV_ListViewOtherAccounts.ItemsSource = new ObservableCollection<Account>(Buffer.Accounts.Where
                (
                        item =>
                        (item.Active == true) &&
                        (item.CustomerId == selectedCustomer.Id) &&
                        (item.Id != selectedCustomer.MainDepositAccountId) &&
                        (item.Id != selectedCustomer.MainNonDepositAccountId)
                )
                );
            CV_ListViewOtherAccounts.UnselectAll();
            CV_ListViewOtherInactiveAccounts.ItemsSource = new ObservableCollection<Account>(Buffer.Accounts.Where
                (
                        item =>
                        (item.Active == false) &&
                        (item.CustomerId == selectedCustomer.Id) &&
                        (item.Id != selectedCustomer.MainDepositAccountId) &&
                        (item.Id != selectedCustomer.MainNonDepositAccountId)
                )
                );
            CV_ListViewOtherInactiveAccounts.UnselectAll();
            CV_ButtonReplenishAccount.Style = Application.Current.FindResource("DisabledButtonStyle") as Style;
            CV_ButtonTransferFromAccount.Style = Application.Current.FindResource("DisabledButtonStyle") as Style;
            CV_ButtonDeactivateAccount.Style = Application.Current.FindResource("DisabledButtonStyle") as Style;
            CV_ButtonActivateAccount.Style = Application.Current.FindResource("DisabledButtonStyle") as Style;
        }

        private void CV_ListViewOtherInactiveAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOtherInactiveAccount = CV_ListViewOtherInactiveAccounts.SelectedItem as Account;
            CV_ButtonActivateAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
        }

        private void CV_ListViewOtherInactiveAccountsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, CV_ListViewOtherInactiveAccounts);
        }

        private void CV_ButtonDeactivateAccount_Click(object sender, RoutedEventArgs e)
        {
            if(selectedOtherActiveAccount != null && MessageBox.Show("Deactivate this account?", "Confirm Deactivate", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                selectedOtherActiveAccount.Active = false;
                Buffer.AccountsStatesLog.Add(new AccountStateLog(selectedOtherActiveAccount, AccountState.Deactivated));
                Buffer.SaveAccountsStatesLog();
                Buffer.SaveAccounts();
                // Calling delegate example
                PopUpNotification deactivationNotification = new PopUpNotification();
                deactivationNotification.FeedData("Deactivation", $"Account #{selectedOtherActiveAccount.Number} was deactivated by user: {Buffer.SelectedUser.Name}");
                deactivationNotification.Notificate += Buffer.MessagePopUp;
                deactivationNotification.Launch();
                // Calling delegate example end
                RefreshListViews();
            }
        }

        private void CV_ButtonActivateAccount_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOtherInactiveAccount != null && MessageBox.Show("Activate this account?", "Confirm Activate", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                selectedOtherInactiveAccount.Active = true;
                Buffer.AccountsStatesLog.Add(new AccountStateLog(selectedOtherInactiveAccount, AccountState.Activated));
                Buffer.SaveAccountsStatesLog();
                Buffer.SaveAccounts();
                // Calling delegate example
                PopUpNotification activationNotification = new PopUpNotification();
                activationNotification.FeedData("Activation",$"Account #{selectedOtherInactiveAccount.Number} was activated by user: {Buffer.SelectedUser.Name}");
                activationNotification.Notificate += Buffer.MessagePopUp;
                activationNotification.Launch();
                // Calling delegate example end
                RefreshListViews();
            }
        }

        private void CV_ButtonReplenishMainDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            CallReplenishWindow(mainDepositAccount);
        }

        private void CallReplenishWindow(Account account)
        {
            ReplenishAccountWindow replenishAccountWindow = new ReplenishAccountWindow(selectedCustomer, account, this);
            replenishAccountWindow.ShowDialog();
        }

        private void CV_ButtonReplenishMainNonDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            CallReplenishWindow(mainNonDepositAccount);
        }

        private void CV_ButtonReplenishAccount_Click(object sender, RoutedEventArgs e)
        {
            if (selectedOtherActiveAccount != null)
            {
                CallReplenishWindow(selectedOtherActiveAccount);
            }
        }

        private void CV_ButtonTransferFromMainDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            CallTransferWindow(mainDepositAccount);
        }

        private void CV_ButtonTransferFromMainNonDepositAccount_Click(object sender, RoutedEventArgs e)
        {
            CallTransferWindow(mainNonDepositAccount);
        }

        private void CV_ButtonTransferFromAccount_Click(object sender, RoutedEventArgs e)
        {
            CallTransferWindow(selectedOtherActiveAccount);
        }

        private void CallTransferWindow(Account account)
        {
            TransferBetweenAccountsWindow transferBetweenAccountsWindow = new TransferBetweenAccountsWindow(account, this);
            transferBetweenAccountsWindow.ShowDialog();
        }
    }
}
