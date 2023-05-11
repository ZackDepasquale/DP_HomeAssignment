using Google.Cloud.Firestore;
using ProductCatalogueMicroservice.Models;
using System;
using System.Collections.Generic;

namespace OrderMicroservice.Models
{
    [FirestoreData]
    public class Order
    {
        [FirestoreProperty]
        public string Id { get; set; }
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public List<Product> Products { get; set; }
        [FirestoreProperty]
        public DateTime OrderDate { get; set; }
        [FirestoreProperty]
        public string Status { get; set; }

        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
