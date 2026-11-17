using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Clubies.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        //needs capital, number, special character, 8-100
        [Required]
        public string Email { get; set; }
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
