using EventsLogger.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos
{
    public record CreateEntryDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; init; }
        [Required]
        public String? Description { get; init; }
        [Required]
        public User? Project { get; init; }
        [Required]
        public User? Manager { get; init; }
        [Required]
        public User? Worker { get; init; }
        [Required]
        public Boolean HasOwnerSeen { get; init; }
        [Required]
        public Boolean HasManagerSeen { get; init; }
        [Required]
        public String[]? Files { get; init; }
    }
}