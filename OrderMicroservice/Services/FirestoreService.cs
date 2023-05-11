using Google.Cloud.Firestore;
using OrderMicroservice.Models;
using System.Threading.Tasks;

namespace OrderMicroservice.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService()
        {
            _firestoreDb = FirestoreDb.Create("distributedprogramming-386215");
        }

        public async Task AddOrder(Order order)
        {
            CollectionReference ordersRef = _firestoreDb.Collection("Orders");
            await ordersRef.AddAsync(order);
        }
    }
}
