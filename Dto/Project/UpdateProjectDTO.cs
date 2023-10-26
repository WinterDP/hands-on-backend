using EventsLogger.Entities;

namespace EventsLogger.Dto.Project
{
    public class UpdateProjectDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        //public required Address Address { get; set; }
        public required string Address { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public Guid[]? UserIds { get; init; }

    }
}
