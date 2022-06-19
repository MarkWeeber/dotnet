using System;
using System.Diagnostics;

namespace app11
{
    public class Manager : User
    {
        public Manager(string Name) : base(Name, UserRole.Manager)
        {

        }

        public void SetFirstName(Customer customer, string NewFirstName)
        {
            CustomerChange change = new CustomerChange(); 
            change.oldFirstName = customer.FirstName;
            change.user = this;
            change.time = DateTime.Now;
            customer.changelog.Add(change);
            customer.FirstName = NewFirstName;
        }

        public void SetLastName(Customer customer, string NewLastName)
        {
            CustomerChange change = new CustomerChange(); 
            change.oldLastName = customer.LastName;
            change.user = this;
            change.time = DateTime.Now;
            customer.changelog.Add(change);
            customer.LastName = NewLastName;
        }

        public void SetMiddleName(Customer customer, string NewMiddleName)
        {
            CustomerChange change = new CustomerChange();
            change.oldMiddleName = customer.MiddleName;
            change.user = this as User;
            change.time = DateTime.Now;
            customer.changelog.Add(change);
            customer.MiddleName = NewMiddleName;
        }

        public void test()
        {
            Debug.WriteLine("TEST_" + Name);
        }

        public void SetPassportNumber(Customer customer, string NewPassportNumber)
        {
            CustomerChange change = new CustomerChange(); 
            change.oldPassportNumber = customer.PassportNumber;
            change.user = this;
            change.time = DateTime.Now;
            customer.changelog.Add(change);
            customer.PassportNumber = NewPassportNumber;
        }

        public void SetPassportSeries(Customer customer, string NewPassportSeries)
        {
            CustomerChange change = new CustomerChange(); 
            change.oldPassportSeries = customer.PassportSeries;
            change.user = this;
            change.time = DateTime.Now;
            customer.changelog.Add(change);
            customer.PassportSeries = NewPassportSeries;
        }
    }
}
