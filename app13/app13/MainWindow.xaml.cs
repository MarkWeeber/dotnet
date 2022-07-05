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
            Buffer.LoadData();
            ListViewCustomers.ItemsSource = Buffer.Customers;
            if(Buffer.Transactions.Any())
            {
                ListViewTransactionHistory.ItemsSource = Buffer.Transactions;
            }
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
            AddNewCustomer addNewCustomer = new AddNewCustomer();
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
