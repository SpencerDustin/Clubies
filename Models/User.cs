using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using VideoGameLibrary.Components.Models;

namespace Clubies.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        public bool IsRegistering { get; set; }

        [Required]
        public string Username { get; set; }
        [RequiredIf(nameof(IsRegistering), true)]
        public string FirstName { get; set; }
        [RequiredIf(nameof(IsRegistering), true)]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        //needs capital, number, special character, 8-100
        [RequiredIf(nameof(IsRegistering), true)]
        public string Email { get; set; }
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
