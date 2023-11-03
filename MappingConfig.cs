using AutoMapper;
using EventsLogger.Dto.Address;
using EventsLogger.Dto.Entry;
using EventsLogger.Dto.Project;
using EventsLogger.Dto.RelationshipProjectUser;
using EventsLogger.Dto.RelationshipUserEntryProject;
using EventsLogger.Dto.User;
using EventsLogger.Entities;

namespace EventsLogger
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<User, UserDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, CreateUserDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UpdateUserDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Project, ProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Project, CreateProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Project, UpdateProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Entry, EntryDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Entry, CreateEntryDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Entry, UpdateEntryDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Address, AddressDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Address, CreateAddressDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Address, UpdateAddressDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RelationshipProjectUsers, RelationshipProjectUsersDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RelationshipProjectUsers, CreateRelationshipProjectUsersDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RelationshipProjectUsers, UpdateRelationshipProjectUsersDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<RelationshipUserEntryProject, RelationshipUserEntryProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RelationshipUserEntryProject, CreateRelationshipUserEntryProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<RelationshipUserEntryProject, UpdateRelationshipUserEntryProjectDTO>().ReverseMap()
                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


        }
    }
}
