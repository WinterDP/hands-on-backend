using EventsLogger.Dto.Address;

namespace EventsLogger.Dto.Project
{
    public class ProjectDTO
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
        public Guid AddressId { get; init; }
        public required AddressDTO Address { get; set; }
        public Guid? CreatorId { get; init; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
