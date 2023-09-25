namespace Entries.Model;

class Entry
{
    public required DateTime TimeStamp { get; set; }
    public required String Project { get; set; }
    public required String Manager { get; set; }
    public required String Worker { get; set; }
    public required Boolean HasOwnerSeen { get; set; }
    public required Boolean HasManagerSeen { get; set; }
    public String[]? Files { get; set; }
}
