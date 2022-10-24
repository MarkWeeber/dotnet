using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace app15
{
    public partial class EditCustomerDetails : Window
    {
        private Customer selectedCustomer;
        public EditCustomerDetails(Customer customer)
        {
            InitializeComponent();
            selectedCustomer = customer;
            SetEditFields();
        }

        private void SetEditFields()
        {
            if(selectedCustomer != null)
            {
                CED_FirstName.Text = selectedCustomer.FirstName;
                CED_LastName.Text = selectedCustomer.LastName;
                CED_MiddleName.Text = selectedCustomer.MiddleName;
                CED_Phone.Text = selectedCustomer.Phone;
                CED_PassportNumber.Text = selectedCustomer.PassportNumber;
                CED_PassportSeries.Text = selectedCustomer.PassportSeries;
            }
        }

        private void RA_ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RA_ButtonReplenish_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCustomer != null)
            {
                Buffer.CustomersChangeLog.Add(
                    new CustomerChange(
                        selectedCustomer,
                        (selectedCustomer.FirstName != CED_FirstName.Text)? selectedCustomer.FirstName : "",
                        (selectedCustomer.LastName != CED_LastName.Text) ? selectedCustomer.LastName : "",
                        (selectedCustomer.MiddleName != CED_MiddleName.Text) ? selectedCustomer.MiddleName : "",
                        (selectedCustomer.Phone != CED_Phone.Text) ? selectedCustomer.Phone : "",
                        (selectedCustomer.PassportNumber != CED_PassportNumber.Text) ? selectedCustomer.PassportNumber : "",
                        (selectedCustomer.PassportSeries != CED_PassportSeries.Text) ? selectedCustomer.PassportSeries : ""
                    ));
                Buffer.SaveCustomersChangeLog();
                selectedCustomer.FirstName = CED_FirstName.Text;
                selectedCustomer.LastName = CED_LastName.Text;
                selectedCustomer.MiddleName = CED_MiddleName.Text;
                selectedCustomer.Phone = CED_Phone.Text;
                selectedCustomer.PassportNumber = CED_PassportNumber.Text;
                selectedCustomer.PassportSeries = CED_PassportSeries.Text;
                // Calling delegate example
                PopUpNotification customerDetailsUpdateNotification = new PopUpNotification();
                customerDetailsUpdateNotification.FeedData("Customer details update", $"Customer with Id {selectedCustomer.Id} was updated by user: {Buffer.SelectedUser.Name}");
                customerDetailsUpdateNotification.Notificate += PopUp.MessagePopUp;
                customerDetailsUpdateNotification.Launch();
                // Calling delegate example end
                Buffer.SaveCustomers();
                this.Close();
            }
        }
    }
}
