namespace EventsLogger.Entities;

public class Project
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateTime? Start { get; set; }
    public string[]? Users { get; set; }
    public string[]? Entries { get; set; }
}
