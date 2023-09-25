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

class FactoryEntry
{
    /// <summary>
    /// Creates a Entry
    /// </summary>
    /// <returns>returns if it was a success or not</returns>
    public String CreateEntry()
    {
        return "TODO";
    }

    /// <summary>
    /// Update a Entry
    /// </summary>
    /// <returns>returns if it was a success or not</returns>
    public String UpdateEntry()
    {
        return "TODO";
    }

    /// <summary>
    /// Delete a Entry
    /// </summary>
    /// <returns>returns if it was a success or not</returns>
    public String DeleteEntry()
    {
        return "TODO";
    }
    /// <summary>
    /// Get a Entry
    /// TODO this functions will access the DB and return the entry
    /// </summary>
    /// <returns>returns if it was a success or not</returns>
    // public Entry ReadEntry()
    // {
    //     return Null;
    // }
}
