using EventsLogger.Entities;
using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos;

public class UpdateUserDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Password { get; set; }
    [EmailAddress]
    [Required, MaxLength(120)]
    public string? Email { get; set; }
    [Required, MaxLength(10)]
    public string? Role { get; set; }
    [Required]
    public string? PhotoPath { get; set; }
    public Project[]? Project { get; set; }
}