using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EmployeeTaskManagement.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public EmployeeRole EmployeeRole { get; set; }

        public ICollection<EmployeeTask> EmployeeTask { get; set; }
    }
}
