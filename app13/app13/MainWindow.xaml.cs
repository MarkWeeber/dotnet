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

namespace app13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user;
        private Resource customerResource;
        private Customer selectedCustomer;
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
        }
    }
}
