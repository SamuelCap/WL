using System.ComponentModel.DataAnnotations;

namespace WebLabsProj.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int EmployeeNumber { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string Surname { get; set; }

        public DateOnly? DoB { get; set; }

        public string? Department { get; set; }
        
        [Required]
        public required string Position { get; set; }
    }
}
