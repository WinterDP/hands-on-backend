using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.EntryServices
{
    public interface IEntryService
    {
        Task<EntryDto> GetEntryAsync(Guid id);
        Task<IEnumerable<EntryDto>> GetEntriesAsync();
        Task CreateEntryAsync(CreateUserDto entry);
        Task UpdateEntryAsync(UpdateUserDto entry);
        Task DeleteEntryAsync(Guid id);
    }
}