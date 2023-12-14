namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber) { }
        
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) 
            : base(accountHolderName, accountNumber, balance) { }

        public override decimal Withdraw(decimal amountToWithdraw)
        {
            // If amount to withdraw is negative, the balance doesn't change. This is taken care of in the BankAccount class.
            // HOWEVER, if the balance started at something less than 150, my code below
            // will tack on the $2 fee. Booooo to this edge case.
            if (amountToWithdraw >= 0)
            {
                decimal newBalance = base.Withdraw(amountToWithdraw);
                if (newBalance < 150 && newBalance >= 2)
                {
                    return base.Withdraw(2);
                }
                else if (newBalance < 2)
                {
                    // Undo the withdrawal from the beginning of the method.
                    return base.Deposit(amountToWithdraw);
                }
                else
                {
                    return newBalance; // or return Balance;
                }
            }
            else
            {
                return Balance;
            }
        }
    }
}
