using System;
using System.Windows;
using System.Diagnostics;
using System.Linq;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;

namespace app12
{
    public partial class MainWindow : Window
    {
        private Resource customerResource;
        private ObservableCollection<Customer> customerDatabase;
        private User selectedUser;
        private Customer selectedCustomer;
        public MainWindow()
        {
            InitializeComponent();
            selectedUser = Buffer.SelectedUser;
            if(selectedUser.UserRole == UserRole.Manager)
            {
                AddNewCustomerButton.Visibility = Visibility.Visible;
            }
            else
            {
                AddNewCustomerButton.Visibility = Visibility.Hidden;
            }
            customerResource = new Resource("customers.json");
            customerDatabase = new ObservableCollection<Customer>();
            Customer.Refresh();
            SelectedUserUI.Text = selectedUser.Credential;
            customerDatabase = customerResource.RetrieveFromJson<ObservableCollection<Customer>>(); // try reading customer database
            if (customerDatabase == null)   // if file not found then create default values for customers
            {
                Debug.WriteLine("customers db file not found, making default values");
                customerDatabase = new ObservableCollection<Customer>();
                Customer.Refresh();
                customerDatabase.Add(new Customer("Adamson", "Adam", "Adam Jr", "55-445321", "1160000", "XP"));
                customerDatabase.Add(new Customer("Brian", "Palma", "De", "55-55123", "1161111", "XP"));
                customerDatabase.Add(new Customer("Rupert", "Murdoc", "Senior", "55-0101010", "1167701", "DM"));
                customerDatabase.Add(new Customer("Nixon", "Flow", "Scott", "554-551234", "1160051", "SS"));
                customerDatabase.Add(new Customer("Jannson", "Greg", "Val", "9-9944-5", "1160016", "DM"));
                customerDatabase.Add(new Customer("Ruyeen", "Sam", "Gross", "0055855123", "1160051", "SS"));
                customerDatabase.Add(new Customer("Karvee", "William", "Rum", "00773123", "1160021", "SS"));
                customerDatabase.Add(new Customer("Samoa", "Josh", "Sent", "55123345", "1160001", "XP"));
                customerResource.SaveToJson(customerDatabase); // saving to json
            }
            CustomerListView.ItemsSource = customerDatabase;
            SortByComboBox.ItemsSource = SortingStruct.GetSortingList();
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void CustomerListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCustomer = CustomerListView.SelectedItem as Customer;
            UpdateCustomerEditForm();
        }
        private void UpdateCustomerEditForm()
        {
            if (CustomerListView.SelectedItem != null)
            {
                EditCustomerFisrtName.Text = selectedCustomer.FirstName;
                EditCustomerLastName.Text = selectedCustomer.LastName;
                EditCustomerMiddleName.Text = selectedCustomer.MiddleName;
                EditCustomerPhone.Text = selectedCustomer.Phone;
                EditCustomerPhone.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                if (selectedUser.UserRole == UserRole.Manager)
                {
                    EditCustomerFisrtName.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                    EditCustomerLastName.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                    EditCustomerMiddleName.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                    EditCustomerPassportNumber.Text = selectedCustomer.PassportNumber;
                    EditCustomerPassportNumber.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                    EditCustomerPassportSeries.Text = selectedCustomer.PassportSeries;
                    EditCustomerPassportSeries.Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                }
                else
                {
                    EditCustomerPassportNumber.Text = "*************";
                    EditCustomerPassportSeries.Text = "*************";
                }
            }
            else
            {
                EditCustomerFisrtName.Text = string.Empty;
                EditCustomerLastName.Text = string.Empty;
                EditCustomerMiddleName.Text = string.Empty;
                EditCustomerPhone.Text = string.Empty;
                EditCustomerPassportNumber.Text = string.Empty;
                EditCustomerPassportSeries.Text = string.Empty;
                EditCustomerFisrtName.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
                EditCustomerLastName.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
                EditCustomerMiddleName.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
                EditCustomerPhone.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
                EditCustomerPassportNumber.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
                EditCustomerPassportSeries.Style = Application.Current.FindResource("StretchedTextBoxReadOnlyStyle") as Style;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCustomer != null)
            {
                int customerIndexToBeChanged = customerDatabase.IndexOf(selectedCustomer);
                if (selectedUser.UserRole == UserRole.Manager)
                {
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
            }
        }

        private void SortByComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e = null)
        {
            customerDatabase.SortCustomExtension(((SortingStruct)SortByComboBox.SelectedItem).Criteria);
            CustomerListView.UnselectAll();
        }

        private void SortByComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if(SortByComboBox.SelectedItem != null)
            {
                SortByComboBox_SelectionChanged(sender);
            }
        }

        private void AddNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedUser.UserRole == UserRole.Manager)
            {
                AddCustomerWindow addCustomerWindow = new AddCustomerWindow(selectedUser, customerDatabase, customerResource);
                addCustomerWindow.ShowDialog();
            }
        }
    }
    public static class ListExtension
    {
        public static void SortCustomExtension(this IList<Customer> list, SortingCriteria criteria)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Customer currentElement = list[j - 1];
                    Customer nextElement = list[j];
                    switch (criteria)
                    {
                        case SortingCriteria.FirstName:
                            if (((IComparable)currentElement.FirstName).CompareTo(nextElement.FirstName) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        case SortingCriteria.LastName:
                            if (((IComparable)currentElement.LastName).CompareTo(nextElement.LastName) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        case SortingCriteria.MiddleName:
                            if (((IComparable)currentElement.MiddleName).CompareTo(nextElement.MiddleName) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        case SortingCriteria.Phone:
                            if (((IComparable)currentElement.Phone).CompareTo(nextElement.Phone) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        case SortingCriteria.PassportSeries:
                            if (((IComparable)currentElement.PassportSeries).CompareTo(nextElement.PassportSeries) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        case SortingCriteria.PassportNumber:
                            if (((IComparable)currentElement.PassportNumber).CompareTo(nextElement.PassportNumber) > 0)
                            {
                                list.Remove(currentElement);
                                list.Insert(j, currentElement);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
