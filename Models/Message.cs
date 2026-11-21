using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clubies.Models
{
    public class Message
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId SenderId { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
