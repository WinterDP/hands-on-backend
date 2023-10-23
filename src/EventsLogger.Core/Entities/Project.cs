namespace EventsLogger.Entities;

public class Project
{
    public Guid Id { get; set; }
    public String? Name { get; set; }
    public String? Address { get; set; }
    public DateTime? Start { get; set; }
    public User[]? Users { get; set; }
    public Entry[]? Entries { get; set; }

    public static implicit operator Project(string v)
    {
        throw new NotImplementedException();
    }
}
