using Google.Cloud.Firestore;
using System;

namespace ShippingMicroservice.Models
{
    [FirestoreData]
    public class ShippingDetails
    {
        [FirestoreProperty]
        public string OrderId { get; set; }

        [FirestoreProperty]
        public string ShippingStatus { get; set; }

        [FirestoreProperty]
        public DateTime ShippingDate { get; set; }
    }
}
