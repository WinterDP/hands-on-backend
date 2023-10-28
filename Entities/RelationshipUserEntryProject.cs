using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsLogger.Entities
{
    /// <summary>
    /// This class represents the Relationship between workers and Entries and Project, the User creates a Entry in a Project
    /// </summary>
    public class RelationshipUserEntryProject
    {

        [ForeignKey("Project")]
        public Guid? ProjectId { get; init; }
        public Project? Project { get; init; }
        

        [ForeignKey("User")]
        public Guid? UserId { get; init; }
        public User? User { get; init; }


        [ForeignKey("Entry")]
        public Guid? EntryId { get; init; }
        public Entry? Entry { get; init; }

        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
    }
}
