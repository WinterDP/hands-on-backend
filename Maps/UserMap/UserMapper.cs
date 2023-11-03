using EventsLogger.Dto.User;
using EventsLogger.Entities;

namespace EventsLogger.Maps.UserMap
{
    public static class UserMapper
    {
        public static User MapToDomain(this UserDTO userDTO)
        {
            User user = new()
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password,
                CreatedDate = userDTO.CreatedDate,
                UpdatedDate = userDTO.UpdatedDate,
                Id = userDTO.Id
            };
            user.Role = userDTO.Role ?? user.Role;
            user.PhotoPath = userDTO.PhotoPath ?? user.PhotoPath;

            return user;
        }

    }
}
