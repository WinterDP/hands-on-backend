using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

<<<<<<< Updated upstream
public class User
{

    public required String Name { get; set; }
    public required String Role { get; set; }
    public required String PhotoPath { get; set; }
    public String[]? Project { get; set; }
=======
namespace EventsLogger.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? Role { get; set; }
        public required string PhotoPath { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        [ForeignKey("Project")]
        public Guid[]? ProjectIds { get; init; }
        public Project[]? Project { get; init; }


    }
>>>>>>> Stashed changes
}