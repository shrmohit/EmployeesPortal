using System.ComponentModel.DataAnnotations;

namespace EmployeesPortal.DTOs
{
    public class LoginDto
    {

        [Required]
        [EmailAddress]
        public String Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
