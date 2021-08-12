namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {
        }
        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {
        }
        public override decimal Withdraw(decimal amountToWithdraw)
        {
            if (Balance - amountToWithdraw < 0 || Balance - (amountToWithdraw + 2) < 0)
            {
                return Balance;
            }
            else if (Balance - amountToWithdraw < 150)
            {
                return base.Withdraw((amountToWithdraw + 2));
            }

            else { return base.Withdraw(amountToWithdraw); }
        }
    }
}
