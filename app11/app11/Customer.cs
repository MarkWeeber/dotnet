using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace app11
{
    public struct CustomerChange
    {
        public User user;
        public DateTime time;
        public string OldFirstName { get; set; }
        public string OldLastName { get; set; }
        public string OldMiddleName { get; set; }
        public string OldPhone { get; set; }
        public string OldPassportSeries { get; set; }
        public string OldPassportNumber { get; set; }
    }

    public class Customer : INotifyPropertyChanged
    {
        public static int incrementor;
        public int Id { get; }
        private string firstName;
        public string FirstName { get { return firstName; } set { SetField(ref firstName, value, "FirstName"); } }
        private string lastName;
        public string LastName { get { return lastName; } set { SetField(ref lastName, value, "LastName"); } }
        private string middleName;
        public string MiddleName { get { return middleName; } set { SetField(ref middleName, value, "MiddleName"); } }
        private string phone;
        public string Phone { get { return phone; } set { SetField(ref phone, value, "Phone"); } }
        private string passportSeries;
        public string PassportSeries { get { return passportSeries; } set { SetField(ref passportSeries, value, "PassportSeries"); } }
        private string passportNumber;
        public string PassportNumber { get { return passportNumber; } set { SetField(ref passportNumber, value, "PassportNumber"); } }
        public List<CustomerChange> changelog;
        static Customer()
        {
            incrementor = 0;
        }
        public Customer(string FirstName, string LastName, string MiddleName, string Phone, string PassportNumber, string PassportSeries)
        {
            Id = ++incrementor;
            changelog = new List<CustomerChange>();
            firstName = FirstName;
            lastName = LastName;
            middleName = MiddleName;
            phone = Phone;
            passportNumber = PassportNumber;
            passportSeries = PassportSeries;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
