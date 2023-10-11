namespace EventsLogger.Entities;

public class Entry
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; init; }
    public String? Description { get; init; }
    public String? Project { get; init; }
    public String? Manager { get; init; }
    public String? Worker { get; init; }
    public Boolean HasOwnerSeen { get; init; }
    public Boolean HasManagerSeen { get; init; }
    public String[]? Files { get; init; }
}
