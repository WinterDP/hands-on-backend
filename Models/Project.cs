using Entries.Model;

namespace ProjectNS.Model;

class Project
{
    public required String Name { get; set; }
    public required String Address { get; set; }
    public required DateTime Start { get; set; }
    public required String[] Users { get; set; }
    public required Entry[] Entries { get; set; }
}
