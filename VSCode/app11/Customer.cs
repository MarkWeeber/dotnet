using System;

namespace app11
{
    public struct CustomerChange
    {
        public User user;
        public DateTime time;
        public string oldFirstName { get; set; }
        public string oldLastName { get; set; }
        public string oldMiddleName { get; set; }
        public string oldPhone { get; set; }
        public string oldPassportSeries { get; set; }
        public string oldPassportNumber { get; set; }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public List<CustomerChange> changelog;
        public Customer(string FirstName, string LastName, string MiddleName, string Phone, string PassportNumber, string PassportSeries)
        {
            this.changelog = new List<CustomerChange>();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.Phone = Phone;
            this.PassportNumber = PassportNumber;
            this.PassportSeries = PassportSeries;
        }
    }
}
