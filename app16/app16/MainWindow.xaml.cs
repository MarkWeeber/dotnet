using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.ComponentModel;
using CommercialBankLibrary_16;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace app16
{
    public partial class MainWindow : Window
    {
        private User user;
        private Customer selectedCustomer;
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private LoadingPopUp loadingPopUp = null;
        private int customerListViewCurrentPageIndex = 1;
        private int customerListViewPageSize = 20;
        private int customerListViewLastPageNumber = 0;

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
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewCurrentPageIndex);
            ListViewTransactionHistory.ItemsSource = Buffer.Transactions;
            ListViewCustomersChangeLog.ItemsSource = Buffer.CustomersChangeLog;
            ListViewAccountsSatesLog.ItemsSource = Buffer.AccountsStatesLog;
        }

        public void RefreshCustomersListView()
        {
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewCurrentPageIndex);
        }

        private void BindPaging<T>(ListView listView, ObservableCollection<T> collection, int page)
        {
            int allowedRange = customerListViewPageSize;
            int maxCount = collection.Count;
            customerListViewLastPageNumber = maxCount / customerListViewPageSize + (int)System.Math.Ceiling((float)maxCount % customerListViewPageSize / customerListViewPageSize);
            if (page >= customerListViewLastPageNumber)
            {
                int remainder = maxCount % customerListViewPageSize;
                page = customerListViewLastPageNumber;
                allowedRange = remainder > 0 ? remainder : customerListViewPageSize;
            }
            customerListViewCurrentPageIndex = page;
            CustomerListViewCurrentPage.Text = page.ToString();
            listView.ItemsSource = collection.ToList().GetRange((page - 1) * customerListViewPageSize, allowedRange);
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
            AddNewCustomer addNewCustomer = new AddNewCustomer(this);
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

        private void CustomerListViewFirstPage_Click(object sender, RoutedEventArgs e)
        {
            customerListViewCurrentPageIndex = 1;
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewCurrentPageIndex);
        }

        private void CustomerListViewNextPage_Click(object sender, RoutedEventArgs e)
        {
            customerListViewCurrentPageIndex++;
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewCurrentPageIndex);
        }

        private void CustomerListViewPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            customerListViewCurrentPageIndex--;
            if (customerListViewCurrentPageIndex < 1)
            {
                customerListViewCurrentPageIndex = 1;
            }
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewCurrentPageIndex);
        }

        private void CustomerListViewLastPage_Click(object sender, RoutedEventArgs e)
        {
            int maxCount = Buffer.Customers.Count;
            customerListViewLastPageNumber = maxCount / customerListViewPageSize + (int)System.Math.Ceiling((float)maxCount % customerListViewPageSize / customerListViewPageSize);
            BindPaging(ListViewCustomers, Buffer.Customers, customerListViewLastPageNumber);
        }
    }
}
