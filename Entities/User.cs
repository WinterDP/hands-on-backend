using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventsLogger.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Role { get; set; }
        public string? PhotoPath { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        [ForeignKey("Project")]
        public Guid[]? ProjectIds { get; init; }
        public Project[]? Project { get; init; }


    }
}