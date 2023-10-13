namespace EventsLogger.Dtos;

public class EntryDto
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; }
    public string? Description { get; set; }
    public string? Project { get; set; }
    public string? Manager { get; set; }
    public string? Worker { get; set; }
    public Boolean HasOwnerSeen { get; set; }
    public Boolean HasManagerSeen { get; set; }
    public string[]? Files { get; set; }
}
