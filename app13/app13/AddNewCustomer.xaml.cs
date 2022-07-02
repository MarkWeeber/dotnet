﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace app13
{
    public partial class AddNewCustomer : Window
    {
        private List<TextBox> InputFields;
        private Resource customerResource;
        public AddNewCustomer(Resource customerResource)
        {
            InitializeComponent();
            this.customerResource = customerResource;
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
                new Customer(
                    InputNewFirstName.Text,
                    InputNewLastName.Text,
                    InputNewMiddleName.Text,
                    InputNewPhone.Text,
                    InputNewPassportNumber.Text,
                    InputNewPassportSeries.Text,
                    Buffer.SelectedUser);
                customerResource.SaveToJson(Buffer.Customers);
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
                customerResource.SaveToJson(Buffer.Customers);
                foreach (var item in InputFields)
                {
                    item.Text = "";
                }
            }
        }
    }
}