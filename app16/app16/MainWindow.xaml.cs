using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.ComponentModel;
using CommercialBankLibrary_16;
using System.Threading;
using System.Threading.Tasks;

namespace app16
{
    public partial class MainWindow : Window
    {
        private User user;
        private Customer selectedCustomer;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private LoadingPopUp loadingPopUp = null;

        public MainWindow()
        {
            InitializeComponent();
            LoadingPopUpShow(); // Show user please wait window
            user = new User("MAIN MANAGER"); // Create current User
            Buffer.SelectedUser = user;
            UserNameTextBlock.Text = $"LOGGED AS: {user.Name}";
            Buffer.DefaultNumberOfClients = 2000;
            Task task1 = new Task(Buffer.LoadData); // Load buffer simultaneously
            task1.Start();
            task1.Wait();
            LoadingPopUpClose();
            task1.Dispose();
            BindListData();
        }

        private void BindListData()
        {
            ListViewCustomers.ItemsSource = Buffer.Customers;
            ListViewTransactionHistory.ItemsSource = Buffer.Transactions;
            ListViewCustomersChangeLog.ItemsSource = Buffer.CustomersChangeLog;
            ListViewAccountsSatesLog.ItemsSource = Buffer.AccountsStatesLog;
        }

        private void CustomersListViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewCustomers);
        }

        private void TransactiontsListViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewTransactionHistory);
        }

        private void ListViewCustomersChangeLogColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewCustomersChangeLog);
        }

        private void ListViewAccountsStatesLogColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            ManageColumnsSorting(sender, ListViewAccountsSatesLog);
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
            EditCustomerDetails.Style = Application.Current.FindResource("NormalButtonStyle") as Style;
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

        private void TransferBetweenTwoCustomers_Click(object sender, RoutedEventArgs e)
        {
            TransferBetweenCustomersWindow transferBetweenCustomersWindow = new TransferBetweenCustomersWindow();
            transferBetweenCustomersWindow.ShowDialog();
        }

        private void EditCustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCustomer != null)
            {
                EditCustomerDetails editCustomerDetails = new EditCustomerDetails(selectedCustomer);
                editCustomerDetails.ShowDialog();
            }
        }

        private void LoadingPopUpShow()
        {
            loadingPopUp = new LoadingPopUp();
            loadingPopUp.Show();
        }

        private void LoadingPopUpClose()
        {
            loadingPopUp.Close();
        }
    }
}
