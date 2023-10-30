using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        private readonly ApplicationDbContext _db;
        public AddressRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task UpdateAsync(Address entity)
        {
            _db.Address.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}

