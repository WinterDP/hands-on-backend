namespace EventsLogger.Entities;

public class User
{

    public required String Name { get; set; }
    public required String Role { get; set; }
    public required String PhotoPath { get; set; }
    public String[]? Project { get; set; }
}