namespace EventsLogger.Entities;

public class Project
{
    public int Id { get; set; }
    public String? Name { get; set; }
    public String? Address { get; set; }
    public DateTime? Start { get; set; }
    public String[]? Users { get; set; }
    public Entry[]? Entries { get; set; }
}
