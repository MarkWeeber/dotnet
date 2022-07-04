using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        public Customer selectedCustomer;
        private Account selectedOtherAccount;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private ObservableCollection<Account> otherAccountsOnSelectedCustomer;
        private Resource accountsResource;
        private Account mainDepositAccount;
        private Account mainNonDepositAccount;
        public CustomerManageWindow(Customer customer, Resource accountsResource)
        {
            InitializeComponent();
            selectedCustomer = customer;
            this.accountsResource = accountsResource;
            // map data
            mainDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => (item.Id == selectedCustomer.MainDepositAccountId)))[0];
            mainNonDepositAccount = new ObservableCollection<Account>(Buffer.Accounts.Where(item => (item.Id == selectedCustomer.MainNonDepositAccountId)))[0];
            CustomerViewTextBlockFirstName.Text = selectedCustomer.FirstName;
            CustomerViewTextBlockLastName.Text = selectedCustomer.LastName;
            CustomerViewTextBlockMiddleName.Text = selectedCustomer.MiddleName;
            CustomerViewTextBlockPhone.Text = selectedCustomer.Phone;
            CustomerViewTextBlockPassportNumber.Text = selectedCustomer.PassportNumber;
            CustomerViewTextBlockPassportSeries.Text = selectedCustomer.PassportSeries;
            CustomerViewTextBlockRegistrationDate.Text = selectedCustomer.CreatedTime;
            CV_MainDepositAccountId.Text = mainDepositAccount.Id.ToString();
            CV_MainDepositAccountNumber.Text = mainDepositAccount.Number.ToString();
            CV_MainDepositAccountBalance.Text = mainDepositAccount.Balance.ToString();
            CV_MainDepositAccountCurrency.Text = mainDepositAccount.Currency.ToString();
            CV_MainNonDepositAccountId.Text = mainNonDepositAccount.Id.ToString();
            CV_MainNonDepositAccountNumber.Text = mainNonDepositAccount.Number.ToString();
            CV_MainNonDepositAccountBalance.Text = mainNonDepositAccount.Balance.ToString();
            CV_MainNonDepositAccountCurrency.Text = mainNonDepositAccount.Currency.ToString();
            RefreshListViews();
        }

        private void CV_ListViewOtherAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedOtherAccount = CV_ListViewOtherAccounts.SelectedItem as Account;
            CV_ButtonReplenishAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
            CV_ButtonTransferFromAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
            CV_ButtonCloseAccount.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
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
            AddNewAccount addNewAccount = new AddNewAccount(accountsResource, selectedCustomer, this);
            addNewAccount.ShowDialog();
        }

        public void RefreshListViews()
        {
            otherAccountsOnSelectedCustomer = new ObservableCollection<Account>(Buffer.Accounts.Where
                (
                        item =>
                        (item.Active == true) &&
                        (item.CustomerId == selectedCustomer.Id) &&
                        (item.Id != selectedCustomer.MainDepositAccountId) &&
                        (item.Id != selectedCustomer.MainNonDepositAccountId)
                )
                );
            CV_ListViewOtherAccounts.ItemsSource = otherAccountsOnSelectedCustomer;
        }
    }
}
