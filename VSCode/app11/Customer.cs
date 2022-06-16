using System;

namespace app11
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public Customer(string FirstName, string LastName, string MiddleName, string Phone, string PassportNumber, string PassportSeries)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MiddleName = MiddleName;
            this.Phone = Phone;
            this.PassportNumber = PassportNumber;
            this.PassportSeries = PassportSeries;
        }
    }
}
