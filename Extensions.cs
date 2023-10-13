using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger
{
    public static class Extensions
    {
        public static EntryDto AsDto(this Entry entry)
        {
            return new EntryDto
            {
                Id = entry.Id,
                CreatedDate = entry.CreatedDate,
                Description = entry.Description,
                Project = entry.Project,
                Manager = entry.Manager,
                Worker = entry.Worker,
                HasOwnerSeen = entry.HasOwnerSeen,
                HasManagerSeen = entry.HasManagerSeen,
                Files = entry.Files
            };
        }
    }
}