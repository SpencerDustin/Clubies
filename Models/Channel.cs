using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clubies.Models
{
    public class Channel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public String Name { get; set; } = "General";
    }
}
