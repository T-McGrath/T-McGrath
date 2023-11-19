using System.ComponentModel.DataAnnotations;

namespace TenmoServer.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required(ErrorMessage = "A user id is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "An account balance is required.")]
        public decimal Balance { get; set; }

        public Account()
        {

        }
        
        public Account(int accountId, int userId, decimal balance)
        {
            AccountId = accountId;
            UserId = userId;
            Balance = balance;
        }
    }
}
