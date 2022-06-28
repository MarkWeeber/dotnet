using System;

namespace app13
{
    public class Manager : User
    {
        public Manager(string Name) : base(Name, UserRole.Manager)
        {

        }

        public void SetFirstName(Customer customer, string NewFirstName)
        {
            CustomerChange change = new CustomerChange();
            change.OldFirstName = customer.FirstName;
            change.LastChangeUser = this;
            change.LastChangeTime = DateTime.Now;
            customer.changelog.Add(change);
            customer.FirstName = NewFirstName;
        }

        public void SetLastName(Customer customer, string NewLastName)
        {
            CustomerChange change = new CustomerChange();
            change.OldLastName = customer.LastName;
            change.LastChangeUser = this;
            change.LastChangeTime = DateTime.Now;
            customer.changelog.Add(change);
            customer.LastName = NewLastName;
        }

        public void SetMiddleName(Customer customer, string NewMiddleName)
        {
            CustomerChange change = new CustomerChange();
            change.OldMiddleName = customer.MiddleName;
            change.LastChangeUser = this as User;
            change.LastChangeTime = DateTime.Now;
            customer.changelog.Add(change);
            customer.MiddleName = NewMiddleName;
        }

        public void SetPassportNumber(Customer customer, string NewPassportNumber)
        {
            CustomerChange change = new CustomerChange();
            change.OldPassportNumber = customer.PassportNumber;
            change.LastChangeUser = this;
            change.LastChangeTime = DateTime.Now;
            customer.changelog.Add(change);
            customer.PassportNumber = NewPassportNumber;
        }

        public void SetPassportSeries(Customer customer, string NewPassportSeries)
        {
            CustomerChange change = new CustomerChange();
            change.OldPassportSeries = customer.PassportSeries;
            change.LastChangeUser = this;
            change.LastChangeTime = DateTime.Now;
            customer.changelog.Add(change);
            customer.PassportSeries = NewPassportSeries;
        }
    }
}
