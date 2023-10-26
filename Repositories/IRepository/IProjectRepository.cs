using EventsLogger.Entities;
using EventsLogger.Repository.IRepository;

namespace EventsLogger.Repositories.IRepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task UpdateAsync(Project entity);

    }
}
