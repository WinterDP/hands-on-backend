namespace EventsLogger.Dtos;

public class ProjectDto
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string[]? Users { get; set; }
    public string[]? Entries { get; set; }
    public DateTime? Start { get; set; }
}
