using System;

namespace WebApplication.Models
{
    public class Shipping
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime ShippingDate { get; set; }
        public string ShippingStatus { get; set; }
        public string DocumentId { get; set; }
    }
}
