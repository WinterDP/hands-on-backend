using System.ComponentModel.DataAnnotations;

namespace EventsLogger.Dtos;

public class CreateUserDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Role { get; set; }
    public string PhotoPath { get; set; }
    public string[] Project { get; set; }
}