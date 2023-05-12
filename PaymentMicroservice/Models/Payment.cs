using Google.Cloud.Firestore;
using Newtonsoft.Json;
using PaymentMicroservice.Converters;
using System;

namespace PaymentMicroservice.Models
{
    [FirestoreData]
    public class Payment
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public string OrderId { get; set; }
        [FirestoreProperty]
        public double Amount { get; set; }
        [FirestoreProperty, JsonConverter(typeof(FirestoreTimestampConverter))]
        public DateTime PaymentDate { get; set; }

        public Payment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
