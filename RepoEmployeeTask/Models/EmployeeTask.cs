using System.ComponentModel.DataAnnotations;

namespace EmployeeTaskManagement.Models
{
    public class EmployeeTask
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string AssignedFrom { get; set; }

        [Required]
        public string AssignedTo { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
