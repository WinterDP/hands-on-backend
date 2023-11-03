using EventsLogger.Dto.Address;

namespace EventsLogger.Dto.Project
{
    public class CreateProjectDTO
    {
        public Guid Id { get; init; }
        public DateTime CreatedDate { get; set; }
        public required string Name { get; set; }
        public Guid AddressId { get; init; }
        public required CreateAddressDTO Address { get; set; }
        public required Guid CreatorId { get; init; }

    }
}
