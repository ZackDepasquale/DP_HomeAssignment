using System;

namespace WebApplication.Models
{
    public class Payment
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Guid Id { get; set; }
    }
}