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
                userDatabase = new List<User>();
                userDatabase = userResource.RetrieveFromJson<List<User>>(); // try reading again
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
                customerDatabase = new ObservableCollection<Customer>(); // clean
                customerDatabase = customerResource.RetrieveFromJson<ObservableCollection<Customer>>(); // try reading again
                if (customerDatabase == null) // if still no database then exit
                {
                    ExitApplication();
                }
            }

            CustomerListView.ItemsSource = customerDatabase; // try mapping
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
