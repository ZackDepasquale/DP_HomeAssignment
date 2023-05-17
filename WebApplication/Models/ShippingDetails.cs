using System;

namespace WebApplication.Models
{
    public class ShippingDetails
    {
        public string OrderId { get; set; }
        public string ShippingStatus { get; set; }
        public DateTime ShippingDate { get; set; }
    }
}
