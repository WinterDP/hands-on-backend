using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class RelationshipProjectUserRepository : Repository<RelationshipProjectUsers>, IRelationshipProjectUserRepository
    {
        private readonly ApplicationDbContext _db;
        public RelationshipProjectUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(RelationshipProjectUsers entity)
        {
            entity.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            _db.RelationshipProjectUsers.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
