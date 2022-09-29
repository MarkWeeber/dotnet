using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace app14
{
    public struct CustomerChange
    {
        public static uint incrementor;
        public uint Id { get; }
        public string LastChangeUserName { get; set; }
        public string LastChangeTime { get; set; }
        public uint CustomerId { get; set; }
        public string OldFirstName { get; set; }
        public string OldLastName { get; set; }
        public string OldMiddleName { get; set; }
        public string OldPhone { get; set; }
        public string OldPassportSeries { get; set; }
        public string OldPassportNumber { get; set; }
        static CustomerChange()
        {
            incrementor = 0;
        }
        public CustomerChange(Customer customer, string oldFirstName, string oldLastName, string oldMiddleName, string oldPhone, string oldPassportSeries, string oldPassportNumber)
        {
            Id = ++incrementor;
            CustomerId = customer.Id;
            OldFirstName = oldFirstName;
            OldLastName = oldLastName;
            OldMiddleName = oldMiddleName;
            OldPhone = oldPhone;
            OldPassportSeries = oldPassportSeries;
            OldPassportNumber = oldPassportNumber;
            LastChangeTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm t");
            LastChangeUserName = Buffer.SelectedUser.Name;
        }
    }

    public enum SortingCriteria
    {
        FirstName, LastName, MiddleName, Phone, PassportSeries, PassportNumber
    }

    public struct SortingStruct
    {
        public SortingCriteria Criteria { get; set; }
        public string CriteriaName { get; set; }
        public static List<SortingStruct> GetSortingList()
        {
            List<SortingStruct> result = new List<SortingStruct>();
            List<SortingCriteria> criterion = Enum.GetValues(typeof(SortingCriteria)).Cast<SortingCriteria>().ToList();
            foreach (SortingCriteria item in criterion)
            {
                SortingStruct sortingStruct = new SortingStruct();
                sortingStruct.Criteria = item;
                switch (item)
                {
                    case SortingCriteria.FirstName:
                        sortingStruct.CriteriaName = "First Name";
                        break;
                    case SortingCriteria.LastName:
                        sortingStruct.CriteriaName = "Last Name";
                        break;
                    case SortingCriteria.MiddleName:
                        sortingStruct.CriteriaName = "Middle Name";
                        break;
                    case SortingCriteria.Phone:
                        sortingStruct.CriteriaName = "Phone";
                        break;
                    case SortingCriteria.PassportSeries:
                        sortingStruct.CriteriaName = "Passport Series";
                        break;
                    case SortingCriteria.PassportNumber:
                        sortingStruct.CriteriaName = "Passport Number";
                        break;
                    default:
                        break;
                }
                result.Add(sortingStruct);
            }
            return result;
        }

    }

    public class Customer : INotifyPropertyChanged
    {
        public static uint incrementor;
        public uint Id { get; }
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
        private string createdTime;
        public string CreatedTime { get { return createdTime; } set { createdTime = value; } }
        public uint createdByUserId { get; set; }
        public uint MainDepositAccountId { get; set; }
        public uint MainNonDepositAccountId { get; set; }
        static Customer()
        {
            incrementor = 0;
        }
        public static void Refresh()
        {
            incrementor = 0;
            Buffer.Customers.Clear();
        }
        public Customer()
        {
            Id = ++incrementor;
        }
        public Customer(string FirstName, string LastName, string MiddleName, string Phone, string PassportNumber, string PassportSeries)
            : this(FirstName, LastName, MiddleName, Phone, PassportNumber, PassportSeries, null)
        {

        }

        public Customer(string FirstName, string LastName, string MiddleName, string Phone, string PassportNumber, string PassportSeries, User user)
        {
            Id = ++incrementor;
            firstName = FirstName;
            lastName = LastName;
            middleName = MiddleName;
            phone = Phone;
            passportNumber = PassportNumber;
            passportSeries = PassportSeries;
            createdTime = DateTime.Now.ToString("dd.MM.yyyy HH:mm t");
            createdByUserId = Buffer.SelectedUser.Id;
            Buffer.Customers.Add(this);
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
        public override string ToString()
        {
            return "Customer: " + firstName.ToString() + " " + lastName.ToString();
        }
    }
}
