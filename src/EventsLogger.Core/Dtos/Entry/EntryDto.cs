using EventsLogger.Entities;

namespace EventsLogger.Dtos;

public class EntryDto
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; init; }
    public String? Description { get; init; }
    public Project? Project { get; init; }
    public User? Manager { get; init; }
    public User? Worker { get; init; }
    public Boolean HasOwnerSeen { get; init; }
    public Boolean HasManagerSeen { get; init; }
    public String[]? Files { get; init; }
}
