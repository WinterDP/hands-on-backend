using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IRelationshipUserEntryProjectRepository : IRepository<RelationshipUserEntryProject>
    {
        Task UpdateAsync(RelationshipUserEntryProject entity);

    }
}
