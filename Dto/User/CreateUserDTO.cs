namespace EventsLogger.Dto.User
{
    public class CreateUserDTO
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string PhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
