using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly ApplicationDbContext _db;
        public EntryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Entry entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Entries.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
