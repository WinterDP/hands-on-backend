using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; init; }
        public User? Owner { get; init; }
    }
}