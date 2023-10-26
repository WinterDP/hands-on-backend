using AutoMapper;
using EventsLogger.Dto.Entry;
using EventsLogger.Dto.Project;
using EventsLogger.Dto.User;
using EventsLogger.Entities;

namespace EventsLogger
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, CreateUserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, CreateProjectDTO>().ReverseMap();
            CreateMap<Project, UpdateProjectDTO>().ReverseMap();

            CreateMap<Entry, EntryDTO>().ReverseMap();
            CreateMap<Entry, CreateEntryDTO>().ReverseMap();
            CreateMap<Entry, UpdateEntryDTO>().ReverseMap();

        }
    }
}
