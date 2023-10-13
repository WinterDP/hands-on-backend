using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos
{
    public record CreateEntryDto
    {
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Project { get; set; }

        [Required]
        public string? Manager { get; set; }

        [Required]
        public string? Worker { get; set; }

        public string[]? Files { get; set; }
    }
}