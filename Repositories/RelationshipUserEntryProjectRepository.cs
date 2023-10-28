using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class RelationshipUserEntryProjectRepository : Repository<RelationshipUserEntryProject>, IRelationshipUserEntryProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public RelationshipUserEntryProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(RelationshipUserEntryProject entity)
        {
            entity.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            _db.RelationshipUserEntryProject.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
