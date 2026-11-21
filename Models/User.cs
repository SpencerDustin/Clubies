using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Clubies.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public required string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
