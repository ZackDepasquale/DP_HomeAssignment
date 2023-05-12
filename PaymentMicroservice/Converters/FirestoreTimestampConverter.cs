using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;

namespace PaymentMicroservice.Converters
{
    public class FirestoreTimestampConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Timestamp timestamp = serializer.Deserialize<Timestamp>(reader);
            return timestamp.ToDateTime();
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            Timestamp timestamp = Timestamp.FromDateTime(value);
            serializer.Serialize(writer, timestamp);
        }
    }
}
