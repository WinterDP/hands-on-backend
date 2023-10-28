using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IRelationshipProjectUserRepository : IRepository<RelationshipProjectUsers>
    {
        Task UpdateAsync(RelationshipProjectUsers entity);

    }
}
