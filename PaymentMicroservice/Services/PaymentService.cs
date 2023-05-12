using Google.Cloud.Firestore;
using PaymentMicroservice.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroservice.Services
{
    public class PaymentService
    {
        private readonly FirestoreDb _firestoreDb;

        public PaymentService(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<Payment> ProcessPayment(Payment payment)
        {
            payment.PaymentDate = DateTime.Now.ToUniversalTime();
            // Save the payment details to Firestore
            CollectionReference paymentsRef = _firestoreDb.Collection("Payments");
            DocumentReference docRef = await paymentsRef.AddAsync(payment);
            payment.Id = docRef.Id;

            return payment;
        }

        public async Task<Payment> GetPaymentByOrderId(string orderId)
        {
            CollectionReference paymentsRef = _firestoreDb.Collection("Payments");
            Query query = paymentsRef.WhereEqualTo("OrderId", orderId);

            QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
            DocumentSnapshot documentSnapshot = querySnapshot.Documents.FirstOrDefault();

            if (documentSnapshot?.Exists == true)
            {
                return documentSnapshot.ConvertTo<Payment>();
            }

            return null;
        }
    }
}
