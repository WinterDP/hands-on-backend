using EventsLogger.Dto.Project;

namespace EventsLogger.Dto.Address
{
    public class CreateAddressDTO
    {
        public Guid Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public Guid ProjectId { get; init; }
        public CreateProjectDTO? CreateProjectDTO { get; init; }


    }
}
