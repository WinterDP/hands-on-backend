using System.Diagnostics.CodeAnalysis;

namespace Entries.Model;

class Entry
{
    private bool? hasManagerSeen;
    private bool? hasOwnerSeen;
    private DateTime? timeStamp;
    [SetsRequiredMembers]
    public Entry(String description, String project, String manager, String worker)
    {
        Description = description;
        Project = project;
        Manager = manager;
        Worker = worker;
    }

    public DateTime? TimeStamp { get => timeStamp; set => timeStamp = DateTime.Now; }
    public required String Description { get; set; }
    public required String Project { get; set; }
    public required String Manager { get; set; }
    public required String Worker { get; set; }
    public Boolean? HasOwnerSeen { get => hasOwnerSeen; set => hasOwnerSeen = false; }
    public Boolean? HasManagerSeen { get => hasManagerSeen; set => hasManagerSeen = false; }
    public String[]? Files { get; set; }
}
