using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos
{
    public record UpdateEntryDto
    {
        [Required]
        public string? Description { get; set; }

        [Required]

        public string? Project { get; set; }

        [Required]

        public string? Manager { get; set; }

        [Required]

        public string? Worker { get; set; }

        [Required]

        public string[]? Files { get; set; }
    }
}