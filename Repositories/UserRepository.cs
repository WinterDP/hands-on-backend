using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(User entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
