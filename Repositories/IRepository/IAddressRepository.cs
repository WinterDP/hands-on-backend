using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task UpdateAsync(Address entity);
    }
}
