using AutoMapper;
using EventsLogger.Data;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsLogger.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserContext _context;

        public UserService(IMapper mapper, UserContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(CreateUserDto newUser)
        {
            if (newUser is null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }
            var user = _mapper.Map<User>(newUser);
            user.Id = Guid.NewGuid();
            await _context.Users.AddAsync(user);
            return await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(Guid id)
        {

            var index = await _context.Users.FindAsync(id);
            if (index is null)
            {
                throw new Exception($"User with Id '{id}' not found.");
            }
            _context.Users.Remove(index);

            return Task.CompletedTask;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var dbUsers = await _context.Users.ToListAsync();
            var user = dbUsers.FirstOrDefault(u => u.Id == id);
            if (user is not null)
            {
                serviceResponse.Data = _mapper.Map<UserDto>(user);
                return serviceResponse;
            }
            throw new Exception("User not found");
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task UpdateUserAsync(UpdateUserDto updatedUser)
        {
            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                var user = dbUsers.FirstOrDefault(u => u.Id == updatedUser.Id);
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