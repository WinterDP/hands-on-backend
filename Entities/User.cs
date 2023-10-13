using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Entities;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [EmailAddress]
    [Required, MaxLength(120)]
    public string? Email { get; set; }
    [Required, MaxLength(10)]
    public string? Role { get; set; }
    public string? PhotoPath { get; set; }
    public string[]? Project { get; set; }
}