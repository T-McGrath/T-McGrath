using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        private IList<IAccountable> accounts = new List<IAccountable>(); // Does List class implement the IList interface?

        public IAccountable[] GetAccounts()
        {
            return accounts.ToArray();
        }

        public void AddAccount(IAccountable newAccount)
        {
            accounts.Add(newAccount);
        }

        public bool IsVip()
        {
            decimal sum = 0;
            foreach (IAccountable account in accounts)
            {
                sum += account.Balance;
            }
            
            return sum >= 25000;
        }
    }
}
