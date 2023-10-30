using EventsLogger.Entities;

namespace EventsLogger.Dto.Project
{
    public class CreateProjectDTO
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; set; }
        public required string Name { get; set; }
        public required Guid OwnerId { get; init; }

    }
}
