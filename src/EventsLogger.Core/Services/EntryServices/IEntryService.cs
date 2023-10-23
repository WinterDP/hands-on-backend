using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.EntryServices
{
    public interface IEntryService
    {
        public Task<ServiceResponse<EntryDto>> GetEntryAsync(Guid id);
        public Task<ServiceResponse<IEnumerable<EntryDto>>> GetEntriesAsync();
        public Task<ServiceResponse<EntryDto>> CreateEntryAsync(CreateUserDto entry);
        public Task<ServiceResponse<EntryDto>> UpdateEntryAsync(UpdateUserDto entry);
        public Task<ServiceResponse<EntryDto>> DeleteEntryAsync(Guid id);
    }
}