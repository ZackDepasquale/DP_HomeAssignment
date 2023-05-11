using Google.Cloud.Firestore;
using System;

namespace CustomerMicroservice.Models
{
    [FirestoreData]
    public class Notification
    {
        [FirestoreProperty]
        public string UserId { get; set; }

        [FirestoreProperty]
        public string Message { get; set; }

        [FirestoreProperty]
        public DateTime Date { get; set; }
    }
}
