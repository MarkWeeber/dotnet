using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.ComponentModel;

namespace app11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Resource userResource, customerResource;
        List<User> userDatabase;
        ObservableCollection<Customer> customerDatabase;
        User selectedUser;
        Customer selectedCustomer;
        public MainWindow()
        {
            InitializeComponent();
            userResource = new Resource("users.json");
            userDatabase = new List<User>();
            customerResource = new Resource("customers.json");
            customerDatabase = new ObservableCollection<Customer>();
            userDatabase = userResource.RetrieveFromJson<List<User>>(); // try reading user database
            if (userDatabase == null)   // if file not found then create default values for users
            {
                Debug.WriteLine("users db file not found, making default values");
                userDatabase = new List<User>();
                userDatabase.Add(new Consultant("Ricardo"));
                userDatabase.Add(new Consultant("Daniel"));
                userDatabase.Add(new Manager("Mike"));
                userDatabase.Add(new Manager("Seaun"));
                userResource.SaveToJson(userDatabase); // saving json
                if(userDatabase == null) // if still no database then exit
                {
                    ExitApplication();
                }
            }
            customerDatabase = customerResource.RetrieveFromJson<ObservableCollection<Customer>>(); // try reading customer database
            if (customerDatabase == null)   // if file not found then create default values for customers
            {
                Debug.WriteLine("customers db file not found, making default values");
                customerDatabase = new ObservableCollection<Customer>();
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "55-445321", "1160000", "XP"));
                customerDatabase.Add(new Customer("Brian", "Palma", "De", "55-55123", "1161111", "XP"));
                customerDatabase.Add(new Customer("Rupert", "Murdoc", "Senior", "55-0101010", "1167701", "DM"));
                customerDatabase.Add(new Customer("Nixon", "Flow", "Scott", "554-551234", "1160051", "SS"));
                customerDatabase.Add(new Customer("Jannson", "Greg", "Val", "9-9944-5", "1160016", "DM"));
                customerDatabase.Add(new Customer("Ruyeen", "Sam", "Gross", "0055855123", "1160051", "SS"));
                customerDatabase.Add(new Customer("Karvee", "William", "Rum", "00773123", "1160021", "SS"));
                customerDatabase.Add(new Customer("Samoa", "Josh", "Sent", "55123345", "1160001", "XP"));
                customerResource.SaveToJson(customerDatabase); // saving to json
                if (customerDatabase == null) // if still no database then exit
                {
                    ExitApplication();
                }
            }
            CustomerListView.ItemsSource = customerDatabase; // mapping customers
            UserSelectComboBox.ItemsSource = userDatabase; // mapping users
        }

        private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserSelectComboBox.SelectedItem != null)
            {
                UpdateCustomerEditForm();
            }
        }

        private void UserSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CustomerListView.SelectedItem != null)
            {
                UpdateCustomerEditForm();
            }
        }

        private void UpdateCustomerEditForm()
        {
            selectedUser = UserSelectComboBox.SelectedItem as User;
            selectedCustomer = CustomerListView.SelectedItem as Customer;
            EditCustomerFisrtName.Text = selectedCustomer.FirstName;
            EditCustomerLastName.Text = selectedCustomer.LastName;
            EditCustomerMiddleName.Text = selectedCustomer.MiddleName;
            EditCustomerPhone.Text = selectedCustomer.Phone;
            if (selectedUser.userRole == UserRole.Manager)
            {
                EditCustomerFisrtName.IsReadOnly = false;
                EditCustomerFisrtName.Background = Brushes.White;
                EditCustomerLastName.IsReadOnly = false;
                EditCustomerLastName.Background = Brushes.White;
                EditCustomerMiddleName.IsReadOnly = false;
                EditCustomerMiddleName.Background = Brushes.White;
                EditCustomerPassportNumber.Text = selectedCustomer.PassportNumber;
                EditCustomerPassportNumber.Background = Brushes.White;
                EditCustomerPassportNumber.IsReadOnly = false;
                EditCustomerPassportSeries.Text = selectedCustomer.PassportSeries;
                EditCustomerPassportSeries.Background = Brushes.White;
                EditCustomerPassportSeries.IsReadOnly = false;
            }
            else
            {
                EditCustomerFisrtName.IsReadOnly = true;
                EditCustomerFisrtName.Background = Brushes.LightGray;
                EditCustomerLastName.IsReadOnly = true;
                EditCustomerLastName.Background = Brushes.LightGray;
                EditCustomerMiddleName.IsReadOnly = true;
                EditCustomerMiddleName.Background = Brushes.LightGray;
                EditCustomerPassportNumber.Text = "*************";
                EditCustomerPassportNumber.Background = Brushes.LightGray;
                EditCustomerPassportNumber.IsReadOnly = true;
                EditCustomerPassportSeries.Text = "*************";
                EditCustomerPassportSeries.Background = Brushes.LightGray;
                EditCustomerPassportSeries.IsReadOnly = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser != null && selectedCustomer != null)
            {
                int customerIndexToBeChanged = customerDatabase.IndexOf(selectedCustomer);
                if (selectedUser.userRole == UserRole.Manager)
                {
                    User currentUser = userDatabase.Find(item => item.Equals(selectedUser));
                    var _parent = JsonConvert.SerializeObject(selectedUser);
                    Manager _manager = JsonConvert.DeserializeObject<Manager>(_parent);
                    if (EditCustomerFisrtName.Text != string.Empty && EditCustomerFisrtName.Text != customerDatabase[customerIndexToBeChanged].FirstName)
                    {
                        _manager.SetFirstName(selectedCustomer, EditCustomerFisrtName.Text);
                    }
                    if (EditCustomerLastName.Text != string.Empty && EditCustomerLastName.Text != customerDatabase[customerIndexToBeChanged].LastName)
                    {
                        _manager.SetLastName(selectedCustomer, EditCustomerLastName.Text);
                    }
                    if (EditCustomerMiddleName.Text != string.Empty && EditCustomerMiddleName.Text != customerDatabase[customerIndexToBeChanged].MiddleName)
                    {
                        _manager.SetMiddleName(selectedCustomer, EditCustomerMiddleName.Text);
                    }
                    if (EditCustomerPassportNumber.Text != string.Empty && EditCustomerPassportNumber.Text != customerDatabase[customerIndexToBeChanged].PassportNumber)
                    {
                        _manager.SetPassportNumber(selectedCustomer, EditCustomerPassportNumber.Text);
                    }
                    if (EditCustomerPassportSeries.Text != string.Empty && EditCustomerPassportSeries.Text != customerDatabase[customerIndexToBeChanged].PassportSeries)
                    {
                        _manager.SetPassportSeries(selectedCustomer, EditCustomerPassportSeries.Text);
                    }
                }
                if (EditCustomerPhone.Text != string.Empty && EditCustomerPhone.Text != customerDatabase[customerIndexToBeChanged].Phone)
                {
                    selectedUser.SetPhone(customerDatabase[customerIndexToBeChanged], EditCustomerPhone.Text);
                }
                customerResource.SaveToJson(customerDatabase);
                ICollectionView _view = CollectionViewSource.GetDefaultView(customerDatabase);
                _view.Refresh();
            }
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
