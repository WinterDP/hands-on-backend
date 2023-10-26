using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Task UpdateAsync(Entry entity);
    }
}
