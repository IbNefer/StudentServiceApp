using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Request.Account
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        [Display(Name = "Email Address")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        // CORRECCIÓN: Cambiado de 'EmailAdress' a 'Email' para coincidir con el repositorio
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        // (Tu regex de password está bien)
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long...")]
        public string Password { get; set; } = string.Empty;
    }
}
