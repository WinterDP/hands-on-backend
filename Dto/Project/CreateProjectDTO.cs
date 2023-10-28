using EventsLogger.Entities;

namespace EventsLogger.Dto.Project
{
    public class CreateProjectDTO
    {
        public Guid Id { get; init; }
        public DateOnly CreatedDate { get; set; }
        public required string Name { get; set; }
        public required Guid OwnerId { get; init; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }

    }
}
