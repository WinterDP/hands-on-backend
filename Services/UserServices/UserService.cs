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

        public async Task<ServiceResponse<IEnumerable<UserDto>>> CreateUserAsync(CreateUserDto newUser)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            var user = _mapper.Map<User>(newUser);
            user.Id = Guid.NewGuid();
            dbUsers.Add(user);
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> DeleteUserAsync(Guid id)
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();

            try
            {
                var dbUsers = await _context.Users.ToListAsync();
                var user = dbUsers.First(u => u.Id == id);
                if (user is null)
                {
                    throw new Exception($"User with Id '{id}' not found.");
                }

                dbUsers.Remove(user);

                serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserDto>(u)).ToList();

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
            var dbUsers = await _context.Users.ToListAsync();
            var user = dbUsers.FirstOrDefault(u => u.Id == id);
            if (user is not null)
            {
                serviceResponse.Data = _mapper.Map<UserDto>(user);
                return serviceResponse;
            }
            throw new Exception("User not found");
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var serviceResponse = new ServiceResponse<IEnumerable<UserDto>>();
            var dbUsers = await _context.Users.ToListAsync();
            serviceResponse.Data = dbUsers.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserDto>> UpdateUserAsync(UpdateUserDto updatedUser)
        {
            var serviceResponse = new ServiceResponse<UserDto>();
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