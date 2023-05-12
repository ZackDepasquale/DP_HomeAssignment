using Google.Cloud.Firestore;

namespace ShippingMicroservice.Models
{
    [FirestoreData]
    public class ShippingStatusUpdate
    {
        [FirestoreProperty]
        public string OrderId { get; set; }
        [FirestoreProperty]
        public string ShippingStatus { get; set; }
    }
}
