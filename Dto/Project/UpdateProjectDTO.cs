using EventsLogger.Dto.Address;

namespace EventsLogger.Dto.Project
{
    public class UpdateProjectDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid AddressId { get; init; }
        public UpdateAddressDTO? Address { get; set; }
        public Guid? CreatorId { get; init; }
        public DateTime UpdatedDate { get; set; }

    }
}
