using Google.Cloud.Firestore;
using System;

namespace ShippingMicroservice.Models
{
    [FirestoreData]
    public class Shipping
    {
        [FirestoreProperty]
        public string Id { get; set; }

        [FirestoreProperty]
        public string OrderId { get; set; }

        [FirestoreProperty]
        public DateTimeOffset ShippingDate { get; set; }

        public Shipping()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
