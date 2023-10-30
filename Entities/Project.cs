using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [ForeignKey("Address")]
        public Guid AddressId { get; init; }
        public Address? Address { get; init; }

        // relationship with the project
        [ForeignKey("Creator")]
        public Guid CreatorId { get; init; }
        public Project? Creator { get; init; }
    }
}