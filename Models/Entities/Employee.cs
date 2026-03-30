using System.ComponentModel.DataAnnotations;

namespace EmployeesPortal.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [Range (18, 65)]
        public int Age { get; set; }
        [Required]
        public string EmployeeName { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        
        public int Salary { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;




    }
}
