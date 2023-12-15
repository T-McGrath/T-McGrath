using System;

namespace Capstone.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public string OrderStatus { get; set; }
        public bool IsDelivery { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
