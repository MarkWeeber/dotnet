using System;

namespace app11
{
    public class Manager : Consultant
    {
        public Manager(string Name)
        {
            base.Consultant(Name);
        }

        public void SetFirstName(Customer customer, string NewFirstName)
        {
            customer.FirstName = NewFirstName;
        }

        public void SetLastName(Customer customer, string NewLastName)
        {
            customer.LastName = NewLastName;
        }

        public void SetMiddleName(Customer customer, string NewMiddleName)
        {
            customer.MiddleName = NewMiddleName;
        }

        public void SetPassportNumber(Customer customer, string NewPassportNumber)
        {
            customer.PassportNumber = NewPassportNumber;
        }

        public void SetPassportSeries(Customer customer, string NewPassportSeries)
        {
            customer.PassportSeries = NewPassportSeries;
        }
    }
}
