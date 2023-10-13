using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos;

public class UpdateProjectDto
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string[]? Users { get; set; }
    [Required]
    public string[]? Entries { get; set; }
    [Required]
    public DateTime? Start { get; set; }
}
