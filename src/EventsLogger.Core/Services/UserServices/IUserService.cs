using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.UserServices
{
    public interface IUserService
    {
        public Task<UserDto> GetUserAsync(Guid id);
        public Task<IEnumerable<UserDto>> GetAllUsersAsync();
        public Task CreateUserAsync(CreateUserDto newUser);
        public Task UpdateUserAsync(UpdateUserDto updatedUser);
        public Task DeleteUserAsync(Guid id);
    }
}