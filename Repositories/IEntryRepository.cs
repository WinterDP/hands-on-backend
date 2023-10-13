using EventsLogger.Entities;

namespace EventsLogger.Repositories
{
    public interface IEntryRepository
    {
        Task<Entry> GetEntryAsync(int id);
        Task<IEnumerable<Entry>> GetEntryAsync();
        Task CreateEntryAsync(Entry entry);
        Task UpdateEntryAsync(Entry entry);
        Task DeleteEntryAsync(int id);
    }
}