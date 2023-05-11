using ProductCatalogueMicroservice.Models;
using System;
using System.Collections.Generic;

namespace OrderMicroservice.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
