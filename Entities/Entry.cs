using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Entities
{
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public string? Description { get; init; }
        [ForeignKey("Worker")]
        public Guid WorkerId { get; init; }
        [ForeignKey("Project")]
        public Guid ProjectId { get; init; }
        public required User Worker { get; init; }
        public required Project Project { get; init; }
        public string[]? Files { get; init; }
    }
}