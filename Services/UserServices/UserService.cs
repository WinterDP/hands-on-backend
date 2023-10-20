using AutoMapper;
using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.UserServices
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>{
            new User(),
            new User { Name = "Lucas"}
        };
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> CreateUserAsync(CreateUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();
            var user = _mapper.Map<User>(newUser);
            user.Id = Guid.NewGuid();
            users.Add(user);
            serviceResponse.Data = users.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> DeleteUserAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();

            try
            {
                var user = users.First(u => u.Id == id);
                if (user is null)
                {
                    throw new Exception($"User with Id '{id}' not found.");
                }

                users.Remove(user);

                serviceResponse.Data = users.Select(u => _mapper.Map<UserDto>(u)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDto>> GetUserAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<UserDto>();
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user is not null)
            {
                serviceResponse.Data = _mapper.Map<UserDto>(user);
                return serviceResponse;
            }
            throw new Exception("User not found");
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> GetUsersAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();
            serviceResponse.Data = users.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDto>> UpdateUserAsync(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<UserDto>();
            try
            {
                var user = users.FirstOrDefault(u => u.Id == updatedUser.Id);
                if (user is null)
                {
                    throw new Exception($"User with Id '{updatedUser.Id}' not found.");
                }

                _mapper.Map(updatedUser, user);

                user.Name = updatedUser.Name;
                user.Password = updatedUser.Password;
                user.Email = updatedUser.Email;
                user.Role = updatedUser.Role;
                user.PhotoPath = updatedUser.PhotoPath;
                user.Projects = updatedUser.Projects;

                serviceResponse.Data = _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;

        }
    }
}