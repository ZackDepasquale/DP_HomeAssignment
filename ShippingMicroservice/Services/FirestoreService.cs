using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;
using ShippingMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShippingMicroservice.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService(IConfiguration configuration)
        {
            string projectId = "distributedprogramming-386215";
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<Shipping> ShipOrder(string orderId)
        {
            CollectionReference shippingRef = _firestoreDb.Collection("Shipping");

            Shipping shipping = new Shipping
            {
                OrderId = orderId,
                ShippingDate = DateTimeOffset.UtcNow
            };

            await shippingRef.AddAsync(shipping);

            return shipping;
        }

        public async Task<List<Shipping>> GetAllShippedOrders()
        {
            Query shippingQuery = _firestoreDb.Collection("Shipping");
            QuerySnapshot querySnapshot = await shippingQuery.GetSnapshotAsync();

            List<Shipping> shippedOrders = new List<Shipping>();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                if (documentSnapshot.Exists)
                {
                    shippedOrders.Add(documentSnapshot.ConvertTo<Shipping>());
                }
            }

            return shippedOrders;
        }

        public void UpdateShippingStatus(string orderId, string shippingStatus, DateTime shippingDate)
        {
            // Create a reference to the shipping document using the orderId
            DocumentReference documentRef = _firestoreDb.Collection("Shipping").Document(orderId);

            // Update the shippingStatus and shippingDate fields in the document
            Dictionary<string, object> updates = new Dictionary<string, object>
            {
                { "ShippingStatus", shippingStatus },
                { "ShippingDate", shippingDate }
            };

            documentRef.UpdateAsync(updates);
        }

        public async Task<ShippingDetails> GetShippingDetails(string orderId)
        {
            DocumentReference documentRef = _firestoreDb.Collection("Shipping").Document(orderId);
            DocumentSnapshot documentSnapshot = await documentRef.GetSnapshotAsync();

            if (documentSnapshot.Exists)
            {
                ShippingDetails shippingDetails = documentSnapshot.ConvertTo<ShippingDetails>();
                return shippingDetails;
            }

            return null;
        }
    }
}
