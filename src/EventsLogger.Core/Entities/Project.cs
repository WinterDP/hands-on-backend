namespace EventsLogger.Entities;

public class Project
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdateDate { get; init; }
    public string? Name { get; set; }
    public required Address Address { get; set; }
    public DateTime? Start { get; set; }
    public User[]? Users { get; set; }
    public Entry[]? Entries { get; set; }

    public static implicit operator Project(string v)
    {
        throw new NotImplementedException();
    }
}
