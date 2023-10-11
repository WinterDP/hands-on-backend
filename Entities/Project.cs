namespace EventsLogger.Entities;

public class Project
{
    public Project(string name, string address)
    {
        this.Name = name;
        this.Address = address;

        this.Start = DateTime.Now;
    }
    public String? Name { get; set; }
    public String? Address { get; set; }
    public DateTime? Start { get; set; }
    public String[]? Users { get; set; }
    public Entry[]? Entries { get; set; }
}
