using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]\\w{3,14}$",ErrorMessage = "Password must have 3 - 14 characters")]
        public string Password { get; set; }
    }
}