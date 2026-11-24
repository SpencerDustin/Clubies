
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoGameLibrary.Components.Models;

namespace Clubies.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [NotMapped]

        public bool IsRegistering { get; set; }
        public string Username { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
        [NotMapped]
        public string ConfirmationPassword { get; set; } = "";
        public string Email { get; set; } = "";
        public string? ProfilePicture { get; set; } = "";
        public string? PhoneNumber { get; set; } = "";
    }
}
