using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialBankLibrary_16
{
    public class OutOfBalanceException : Exception
    {
        public Account SourceAccount { get { return sourceAccount; } }
        private Account sourceAccount;
        public OutOfBalanceException (Account sourceAccount)
        {
            this.sourceAccount = sourceAccount;
        }
    }
}
