using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Entities
{
    /// <summary>
    /// This class represents the workers and managers that is working on the project
    /// </summary>
    public class RelationshipProjectUsers
    {

        [ForeignKey("Project")]
        public Guid? ProjectId { get; init; }
        public Project? Project { get; init; }
        

        [ForeignKey("User")]
        public Guid? UserId { get; init; }
        public User? User { get; init; }
        public required string Role { get; set; }

    }
}
