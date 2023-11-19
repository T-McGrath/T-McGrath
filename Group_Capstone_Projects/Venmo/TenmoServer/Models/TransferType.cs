namespace TenmoServer.Models
{
    public class TransferType
    {
        public int TransferTypeId { get; set; }

        public string TransferTypeDesc { get; set; }

        // Do we need a constructor that takes parameters? Don't think we do because we are 
        // getting these values from a database.
    }
}
