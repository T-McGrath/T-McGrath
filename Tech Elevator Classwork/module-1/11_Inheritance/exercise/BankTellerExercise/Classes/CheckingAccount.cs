namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber) { }

        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance) { }


        public override decimal Withdraw(decimal amountToWithdraw)
        {
            decimal newBalance = base.Withdraw(amountToWithdraw);

            if (newBalance < 0 && newBalance > -100.00M)
            {
                // $10 fee is same idea as taking away $10 from balance
                return base.Withdraw(10);
            }
            if(newBalance <= -100.00M)
            {
                // Do not allow the withdrawal...or in my case, undo it by depositing the same amount back in
                return base.Deposit(amountToWithdraw);
            }
            return Balance;
            

        }
    }
}
