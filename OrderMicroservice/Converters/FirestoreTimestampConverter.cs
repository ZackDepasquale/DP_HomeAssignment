using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;

namespace OrderMicroservice.Converters
{
    public class FirestoreTimestampConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Timestamp firestoreTimestamp = serializer.Deserialize<Timestamp>(reader);
            return firestoreTimestamp.ToDateTime();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
