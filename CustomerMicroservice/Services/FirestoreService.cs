using CustomerMicroservice.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirestoreService()
        {
            _firestoreDb = FirestoreDb.Create("distributedprogramming-386215");
        }

        public async Task AddUser(User user)
        {
            CollectionReference usersRef = _firestoreDb.Collection("Users");
            await usersRef.AddAsync(user);
        }

        public async Task<(User, string)> GetUserByEmail(string email)
        {
            Query query = _firestoreDb.Collection("Users").WhereEqualTo("Email", email);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            if (snapshot.Count > 0)
            {
                DocumentSnapshot documentSnapshot = snapshot[0];
                return (documentSnapshot.ConvertTo<User>(), documentSnapshot.Id);
            }

            return (null, null);
        }

        public async Task<(User, string)> GetUserDetails(string email)
        {
            Query query = _firestoreDb.Collection("Users").WhereEqualTo("Email", email);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            if (snapshot.Count > 0)
            {
                DocumentSnapshot documentSnapshot = snapshot.Documents[0];
                return (documentSnapshot.ConvertTo<User>(), documentSnapshot.Id);
            }

            return (null, null);
        }

        public async Task AddNotification(string userId, string message)
        {
            Notification notification = new Notification
            {
                UserId = userId,
                Message = message,
                Date = DateTime.UtcNow
            };

            CollectionReference notificationsRef = _firestoreDb.Collection("Notifications");
            await notificationsRef.AddAsync(notification);
        }

        public async Task<List<Notification>> GetNotifications(string userId)
        {
            Query query = _firestoreDb.Collection("Notifications").WhereEqualTo("UserId", userId);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents.Select(document => document.ConvertTo<Notification>()).ToList();
        }
    }
}
