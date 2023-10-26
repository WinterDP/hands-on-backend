using EventsLogger.Entities;

namespace EventsLogger.Dto.Project
{
    public class CreateProjectDTO
    {
        public Guid Id { get; init; }
        public DateOnly CreatedDate { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public Guid[]? UserIds { get; init; }

    }
}
