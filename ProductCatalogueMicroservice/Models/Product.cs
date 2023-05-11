using Google.Cloud.Firestore;

namespace ProductCatalogueMicroservice.Models
{
    [FirestoreData]
    public class Product
    {
        [FirestoreProperty]
        public int Id { get; set; }
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public double Price { get; set; }
        [FirestoreProperty]
        public string Category { get; set; }
        [FirestoreProperty]
        public string Image { get; set; }
    }
}
