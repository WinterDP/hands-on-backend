namespace EventsLogger.Dto.Entry
{
    public class CreateEntryDTO
    {
        public Guid Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string? Description { get; init; }
        public Guid WorkerId { get; init; }
        public Guid ProjectId { get; init; }
        public string[]? Files { get; init; }
    }

}