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

namespace app14
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
                selectedCustomer.FirstName = CED_FirstName.Text;
                selectedCustomer.LastName = CED_LastName.Text;
                selectedCustomer.MiddleName = CED_MiddleName.Text;
                selectedCustomer.Phone = CED_Phone.Text;
                selectedCustomer.PassportNumber = CED_PassportNumber.Text;
                selectedCustomer.PassportSeries = CED_PassportSeries.Text;
                Buffer.SaveCustomers();
                this.Close();
            }
        }
    }
}
