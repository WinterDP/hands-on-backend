namespace EventsLogger.Dto.Project
{
    public class ProjectDTO
    {
        public Guid Id { get; init; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public Guid[]? UserIds { get; init; }

    }
}
