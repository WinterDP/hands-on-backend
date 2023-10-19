using EventsLogger.Entities;

namespace EventsLogger.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry> GetEntryAsync(Guid id);
        Task<IEnumerable<Entry>> GetEntryAsync();
        Task CreateEntryAsync(Entry entry);
        Task UpdateEntryAsync(Entry entry);
        Task DeleteEntryAsync(Guid id);
    }
}