using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clubies.Models
{
    public class ClubEvent
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId PostedBy { get; set; }
        public string Description { get; set; } = "Club information.";
        public DateTime TimeOfPost { get; set; }
    }
}
