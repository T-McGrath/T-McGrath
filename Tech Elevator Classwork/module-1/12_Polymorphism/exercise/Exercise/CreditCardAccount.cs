using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class CreditCardAccount : IAccountable
    {
        public string AccountHolderName { get; private set; }
        public string CardNumber { get; }
        public decimal Debt { get; private set; }

        public decimal Balance
        {
            get
            {
                return (-1) * Debt;
            }
        }

        public CreditCardAccount(string accountHolderName, string cardNumber)
        {
            AccountHolderName = accountHolderName;
            CardNumber =  cardNumber;
            Debt = 0;
        }

        public decimal Pay(decimal amountToPay)
        {
            if (amountToPay > 0)
            {
                Debt -= amountToPay;
            }            
            return Debt;
        }

        public decimal Charge(decimal amountToCharge)
        {
            if (amountToCharge > 0)
            {
                Debt += amountToCharge;
            }
            return Debt;
        }
    }
}
