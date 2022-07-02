using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace app13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private Resource customerResource;
        private Resource accountsResource;
        private Resource transactionResource;
        private Customer selectedCustomer;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            // Create current User and initialize buffer
            user = new User("MAIN MANAGER");
            Buffer.SelectedUser = user;
            UserNameTextBlock.Text = user.Name;
            // Customers database - retreive from json, or create default values
            customerResource = new Resource("customers.json");
            Customer.Refresh();
            Buffer.Customers = customerResource.RetrieveFromJson(Buffer.Customers);
            if (!Buffer.Customers.Any())
            {
                Debug.WriteLine("Customers data not found or corrupted, making default values");
                new Customer("Adamson", "Adam", "Adam Jr", "55-445321", "1160000", "XP");
                new Customer("Brian", "Palma", "De", "55-55123", "1161111", "XP");
                new Customer("Rupert", "Murdoc", "Senior", "55-0101010", "1167701", "DM");
                new Customer("Nixon", "Flow", "Scott", "554-551234", "1160051", "SS");
                new Customer("Jannson", "Greg", "Val", "9-9944-5", "1160016", "DM");
                new Customer("Ruyeen", "Sam", "Gross", "0055855123", "1160051", "SS");
                new Customer("Karvee", "William", "Rum", "00773123", "1160021", "SS");
                new Customer("Samoa", "Josh", "Sent", "55123345", "1160001", "XP");
                customerResource.SaveToJson(Buffer.Customers);
            }
            ListViewCustomers.ItemsSource = Buffer.Customers;
            // Accounts database - retreive from json
            accountsResource = new Resource("accounts.json");
            Buffer.Accounts = accountsResource.RetrieveFromJson(Buffer.Accounts);
            if(!Buffer.Accounts.Any())
            {
                Debug.WriteLine("Accounts data not found");
            }
            // Transactions database - retreive from json
            transactionResource = new Resource("transactions.json");
            Transaction<Type>.Refresh();
            Transaction<Type>.Transactions = transactionResource.RetrieveFromJson(Transaction<Type>.Transactions);
            if(!Transaction<Type>.Transactions.Any())
            {
                Debug.WriteLine("Transactions data not found");
            }
            ListViewTransactionHistory.ItemsSource = Transaction<Type>.Transactions;

        }

        private void CustomersListViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewCustomers);
        }

        private void TransactiontsListViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewTransactionHistory);
        }

        private void ManageColumnsSorting(object sender, ListView listView)
        {
            if(listView != null)
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

        private void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddNewCustomer addNewCustomer = new AddNewCustomer(customerResource);
            addNewCustomer.ShowDialog();
        }

        private void ListViewCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCustomer = ListViewCustomers.SelectedItem as Customer;
            ShowCustomerAccounts.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
        }

        private void ListViewCustomers_Unselect()
        {
            ShowCustomerAccounts.Style = Application.Current.FindResource("DisabledButtonStyle") as Style;
            ListViewCustomers.UnselectAll();
        }

        private void ShowCustomerAccounts_Click(object sender, RoutedEventArgs e)
        {
            if(selectedCustomer != null)
            {
                CustomerManageWindow customerManageWindow = new CustomerManageWindow(selectedCustomer);
                customerManageWindow.ShowDialog();
            }
        }
    }
}
