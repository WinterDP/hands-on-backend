using EventsLogger.Entities;

namespace EventsLogger.Repositories
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectAsync(Guid id);
        Task<IEnumerable<Project>> GetProjectAsync();
        Task CreateProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Guid id);
    }
}