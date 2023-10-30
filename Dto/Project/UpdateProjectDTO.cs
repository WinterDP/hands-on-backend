using EventsLogger.Entities;

namespace EventsLogger.Dto.Project
{
    public class UpdateProjectDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
