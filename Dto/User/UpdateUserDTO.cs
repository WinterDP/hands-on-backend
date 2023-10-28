namespace EventsLogger.Dto.User
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhotoPath { get; set; }
        public Guid? OwnerId { get; init; }
        public DateOnly UpdatedDate { get; set; }

    }
}
