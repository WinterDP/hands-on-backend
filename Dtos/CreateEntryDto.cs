using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos
{
    public record CreateEntryDto
    {
        [Required]
        public String? Description { get; set; }

        [Required]

        public String? Project { get; set; }

        [Required]

        public String? Manager { get; set; }

        [Required]

        public String? Worker { get; set; }

        [Required]

        public String[]? Files { get; set; }
    }
}