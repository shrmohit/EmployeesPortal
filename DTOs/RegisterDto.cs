using System.ComponentModel.DataAnnotations;

namespace EmployeesPortal.DTOs
{
    public class RegisterDto
    {

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public String PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public String Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

       
    }
}
