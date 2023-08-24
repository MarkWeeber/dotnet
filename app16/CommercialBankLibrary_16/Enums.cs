namespace CommercialBankLibrary_16
{
    public enum AccountType
    {
        Deposit,
        NonDeposit
    }

    public enum Currency
    {
        EUR, USD, RUB, GBP
    }

    public enum TransactionType
    {
        Default, BetweenAccounts, Replenishment, WithDrawal
    }
}
