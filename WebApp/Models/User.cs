using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Auth
{
    public class User
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}