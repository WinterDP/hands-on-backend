using EventsLogger.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }

    [EmailAddress]
    [Required, MaxLength(120)]
    public string? Email { get; set; }
    public UserRoles Role { get; set; } = UserRoles.worker;

    public string? PhotoPath { get; set; }
    public Project[]? Project { get; set; }
}
