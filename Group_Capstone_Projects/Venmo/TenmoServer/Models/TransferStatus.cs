namespace TenmoServer.Models
{
    public class TransferStatus
    {
        public int TransferStatusId { get; set; }

        public string TransferStatusDesc { get; set; }

        // Do we need a constructor with parameters? Don't think we do because we are 
        // getting these values from a database.
    }
}
