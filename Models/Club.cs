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
        public ObjectId Owner { get; set; }
        public List<ObjectId>? ClubEvents { get; set; }
        public List<ObjectId>? Managers { get; set; }
        public List<ObjectId>? Channels { get; set; }
        public List<ObjectId>? Members { get; set; }
        public string? ClubPhoto { get; set; }
        public List<Tags>? ClubTags { get; set; }
    }
}
