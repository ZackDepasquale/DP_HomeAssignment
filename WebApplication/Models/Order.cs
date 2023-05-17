using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Order
    {
        public Guid  Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
