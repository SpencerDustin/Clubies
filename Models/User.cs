
using System.ComponentModel.DataAnnotations;
using VideoGameLibrary.Components.Models;

namespace Clubies.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        public bool IsRegistering { get; set; }
        public string Username { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmationPassword { get; set; } = "";
        public string Email { get; set; } = "";
        public string? ProfilePicture { get; set; } = "";
        public string? PhoneNumber { get; set; } = "";
    }
}
