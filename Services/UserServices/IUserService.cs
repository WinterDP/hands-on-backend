using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.UserServices
{
    public interface IUserService
    {
        Task<ServiceResponse<UserDto>> GetUserAsync(Guid id);
        Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task<ServiceResponse<IEnumerable<UserDto>>> CreateUserAsync(CreateUserDto newUser);
        Task<ServiceResponse<UserDto>> UpdateUserAsync(UpdateUserDto updatedUser);
        Task<ServiceResponse<IEnumerable<UserDto>>> DeleteUserAsync(Guid id);
    }
}