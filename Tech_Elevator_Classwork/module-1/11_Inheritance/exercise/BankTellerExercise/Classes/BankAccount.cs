namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        public BankAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            //Balance = 0;
        }

        public BankAccount(string accountHolderName, string accountNumber, decimal balance)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; }
        public decimal Balance { get; private set; } = 0;

       
        public decimal Deposit(decimal amountToDeposit)
        {
            if (amountToDeposit > 0M)
            {
                Balance += amountToDeposit;
            }
            return Balance;
        }

        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > 0M)
            {
                Balance -= amountToWithdraw;
            }
            return Balance;
        }
    }
}
