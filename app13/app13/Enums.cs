namespace app13
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
        BetweenAccounts, Replenishment, WithDrawal
    }
}
