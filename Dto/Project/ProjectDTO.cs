namespace EventsLogger.Dto.Project
{
    public class ProjectDTO
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public required string Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public Guid? OwnerId { get; init; }

    }
}
