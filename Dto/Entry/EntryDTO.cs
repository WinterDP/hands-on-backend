namespace EventsLogger.Dto.Entry
{
    public class EntryDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? Description { get; init; }
        public string[]? Files { get; init; }
    }
}
