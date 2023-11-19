using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    public class Transfer
    {
        public int TransferId { get; set; }

        [Required(ErrorMessage = "Transfer type ID is required.")]
        public int TransferTypeId { get; set; }

        [Required(ErrorMessage = "Transfer status ID is required.")]
        public int TransferStatusId { get; set; }

        [Required(ErrorMessage = "From account ID is required.")]
        public int AccountFrom { get; set; }

        [Required(ErrorMessage = "To account ID is required.")]
        public int AccountTo { get; set; }

        [Required(ErrorMessage = "Transfer amount is required.")]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        public Transfer()
        {

        }

        public Transfer(int transferId, int transferTypeId, int transferStatusId, int accountFrom, int accountTo, decimal amount)
        {
            TransferId = transferId;
            TransferTypeId = transferTypeId;
            TransferStatusId = transferStatusId;
            AccountFrom = accountFrom;
            AccountTo = accountTo;
            Amount = amount;
        }
    }
}
