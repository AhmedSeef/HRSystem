using System.ComponentModel.DataAnnotations;

namespace HRSystem.DTO
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "You must enter a correct email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "you must enter the password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$",
            ErrorMessage = "Password must meet requirements")]
        public string Password { get; set; }
    }
}