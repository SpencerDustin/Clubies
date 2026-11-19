using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Clubies.Models.Enums;

namespace Clubies.Models
{
    public class Club
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [BsonId]
        public ObjectId Owner { get; set; }
        [BsonId]
        public List<ObjectId>? ClubEvents { get; set; }
        [BsonId]
        public List<ObjectId>? Managers { get; set; }
        [BsonId]
        public List<ObjectId>? Channels { get; set; }
        [BsonId]
        public List<ObjectId>? Members { get; set; }
        public string? ClubPhoto { get; set; }
        public List<Tags>? ClubTags { get; set; }
    }
}
