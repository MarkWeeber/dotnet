using System;

namespace app11
{
    public class AccessTester
    {
        Consultant adam = new Consultant("Adam");
        Customer sam = new Customer("Molko", "Brian", "Ceevu", "1134", "885123", "XP100");
        private void main()
        {
            adam.ReadFirstName(sam);
        }
    }
}
