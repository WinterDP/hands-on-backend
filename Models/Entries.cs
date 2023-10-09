namespace Entries.Model;

public class Entry
{
    public Entry(String description, String project, String manager, String worker)
    {
        this.Description = description;
        this.Project = project;
        this.Manager = manager;
        this.Worker = worker;

        this.HasManagerSeen = false;
        this.HasOwnerSeen = false;
        this.TimeStamp = DateTime.Now;
    }

    public DateTime? TimeStamp { get; set; }
    public String? Description { get; set; }
    public String? Project { get; set; }
    public String? Manager { get; set; }
    public String? Worker { get; set; }
    public Boolean? HasOwnerSeen { get; set; }
    public Boolean? HasManagerSeen { get; set; }
    public String[]? Files { get; set; }
}
