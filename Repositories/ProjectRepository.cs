using EventsLogger.Data;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;

namespace EventsLogger.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Project entity)
        {
            entity.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
            _db.Projects.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
