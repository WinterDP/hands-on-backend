namespace EventsLogger.Dto.Entry
{
    public class CreateEntryDTO
    {
        public Guid Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public string? Description { get; init; }
        public string[]? Files { get; init; }
    }

}