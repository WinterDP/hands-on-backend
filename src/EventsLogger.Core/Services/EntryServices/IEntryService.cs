using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.EntryServices
{
    public interface IEntryService
    {
        public Task<EntryDto> GetEntryAsync(Guid id);
        public Task<IEnumerable<EntryDto>> GetEntriesAsync();
        public Task<EntryDto> CreateEntryAsync(CreateUserDto entry);
        public Task UpdateEntryAsync(UpdateUserDto entry);
        public Task DeleteEntryAsync(Guid id);
    }
}