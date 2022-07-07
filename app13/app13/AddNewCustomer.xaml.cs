using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace app13
{
    public partial class AddNewCustomer : Window
    {
        private List<TextBox> InputFields;
        public AddNewCustomer()
        {
            InitializeComponent();
            InputFields = new List<TextBox>() { InputNewFirstName, InputNewLastName, InputNewMiddleName, InputNewPhone, InputNewPassportNumber, InputNewPassportSeries };
        }

        private void CancelAddingNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddNewCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            bool emptyFieldChecker = false;
            for (int i = 0; i < InputFields.Count; i++)
            {
                if (InputFields[i].Text == string.Empty)
                {
                    InputFields[i].Style = Application.Current.FindResource("StretchedWarningTextBoxStyle") as Style;
                    emptyFieldChecker = true;
                }
                else
                {
                    InputFields[i].Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                }
            }
            if (!emptyFieldChecker)
            {
                Customer newCustomer = new Customer(
                    InputNewFirstName.Text,
                    InputNewLastName.Text,
                    InputNewMiddleName.Text,
                    InputNewPhone.Text,
                    InputNewPassportNumber.Text,
                    InputNewPassportSeries.Text,
                    Buffer.SelectedUser);
                newCustomer.MainDepositAccountId = new DepositAccount(newCustomer.Id, Currency.RUB).Id;
                newCustomer.MainNonDepositAccountId = new NonDepositAccount(newCustomer.Id, Currency.RUB).Id;
                Buffer.SaveCustomers();
                Buffer.SaveAccounts();
                this.Close();
            }
        }

        private void AddNewCustomerContniueButton_Click(object sender, RoutedEventArgs e)
        {
            bool emptyFieldChecker = false;
            for (int i = 0; i < InputFields.Count; i++)
            {
                if (InputFields[i].Text == string.Empty)
                {
                    InputFields[i].Style = Application.Current.FindResource("StretchedWarningTextBoxStyle") as Style;
                    emptyFieldChecker = true;
                }
                else
                {
                    InputFields[i].Style = Application.Current.FindResource("StretchedTextBoxStyle") as Style;
                }
            }
            if (!emptyFieldChecker)
            {
                Customer newCustomer = new Customer(
                    InputNewFirstName.Text,
                    InputNewLastName.Text,
                    InputNewMiddleName.Text,
                    InputNewPhone.Text,
                    InputNewPassportNumber.Text,
                    InputNewPassportSeries.Text,
                    Buffer.SelectedUser);
                newCustomer.MainDepositAccountId = new DepositAccount(newCustomer.Id, Currency.RUB).Id;
                newCustomer.MainNonDepositAccountId = new NonDepositAccount(newCustomer.Id, Currency.RUB).Id;
                Buffer.SaveCustomers();
                Buffer.SaveAccounts();
                foreach (var item in InputFields)
                {
                    item.Text = "";
                }
            }
        }
    }
}
