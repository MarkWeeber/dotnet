using System;

namespace app11
{
    public class Consultant : User
    {
        public Consultant(string Name)
        {
            base.User(Name);
        }

        public string ReadFirstName(Customer customer)
        {
            return customer.FirstName;
        }

        public string ReadLastName(Customer customer)
        {
            return customer.LastName;
        }

        public string ReadMiddleName(Customer customer)
        {
            return customer.MiddleName;
        }

        public void SetPhone(Customer customer, string NewPhone)
        {
            if (NewPhone != String.Empty)
            {
                customer.Phone = NewPhone;
            }
        }

        public string ReadPassportNumber(Customer customer)
        {
            string ans = String.Empty;
            if (customer.PassportNumber != String.Empty)
            {
                ans = "********";
            }
            return ans;
        }

        public string ReadPassportSeries(Customer customer)
        {
            string ans = String.Empty;
            if (customer.PassportSeries != String.Empty)
            {
                ans = "********";
            }
            return ans;
        }
    }
}
