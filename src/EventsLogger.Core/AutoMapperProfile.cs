using AutoMapper;
using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();


        }
    }
}