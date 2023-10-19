using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    [EmailAddress]
    [Required, MaxLength(120)]
    public string? Email { get; set; }
    [Required, MaxLength(10)]
    public UserRoles Role { get; set; } = UserRoles.worker;
    public string? PhotoPath { get; set; }
    public Project[]? Project { get; set; }

    public static implicit operator User(string v)
    {
        throw new NotImplementedException();
    }
}