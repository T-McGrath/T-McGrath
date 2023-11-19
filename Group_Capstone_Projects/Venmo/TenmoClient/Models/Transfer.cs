using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenmoClient.Models
{
    public class Transfer
    {
        //[Required] Should we add this?
        public int TransferId { get; set; }

        public int TransferTypeId { get; set; }

        public int TransferStatusId { get; set; }

        public int AccountFrom {get; set; } //This is actually the user ID of the 'from' account holder rather than the account number.

        public int AccountTo { get; set; } //This is actually the user ID of the 'to' account holder rather than the account number.

        public decimal Amount { get; set; }

        public Transfer()
        {

        }

        public Transfer(int transferId, int transferTypeId, int accountFrom, int accountTo, decimal amount)
        {
            TransferId = transferId;
            TransferTypeId = transferTypeId;
            AccountFrom = accountFrom;
            AccountTo = accountTo;
            Amount = amount;
        }
    }
}
