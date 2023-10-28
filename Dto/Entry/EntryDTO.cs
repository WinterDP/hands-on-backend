﻿namespace EventsLogger.Dto.Entry
{
    public class EntryDTO
    {
        public Guid Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly UpdatedDate { get; set; }
        public string? Description { get; init; }
        public string[]? Files { get; init; }
    }
}
