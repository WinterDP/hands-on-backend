namespace EventsLogger.Dtos;

public class EntryDto
{
    public Guid Id { get; init; }
    public DateTime CreatedDate { get; set; }
    public String? Description { get; set; }
    public String? Project { get; set; }
    public String? Manager { get; set; }
    public String? Worker { get; set; }
    public Boolean HasOwnerSeen { get; set; }
    public Boolean HasManagerSeen { get; set; }
    public String[]? Files { get; set; }
}
