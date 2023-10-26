using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task UpdateAsync(User entity);
    
    }
}
