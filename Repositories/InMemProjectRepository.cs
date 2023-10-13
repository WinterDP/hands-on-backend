using EventsLogger.Entities;

namespace EventsLogger.Repositories
{

    public class InMemProjectRepository : IProjectRepository
    {
        private readonly List<Project> projects = new()
        {
            new Project
            {
                Name = "Project 1",
                Address = "Addres 1",
                Start = DateTime.Now,
                Users = ["User 1"],
                Entries = ["Entry 1"]
            },
            new Project
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Description = "Finish the Walls.",
                Project = "Building 2",
                Manager = "Manager 2",
                Worker = "Worker 2",
                HasOwnerSeen = false,
                HasManagerSeen = false,
                Files = null
            },
            new Project
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Description = "Finish the Doors.",
                Project = "Building 3",
                Manager = "Manager 3",
                Worker = "Worker 3",
                HasOwnerSeen = false,
                HasManagerSeen = false,
                Files = null
            }
        };

        public async Task<IEnumerable<Project>> GetProjectAsync()
        {
            return await Task.FromResult(projects);
        }

        public async Task<Project> GetProjectAsync(Guid id)
        {
            var project = projects.SingleOrDefault(project => project.Id == id)!;
            return await Task.FromResult(project);
        }

        public async Task CreateProjectAsync(Project project)
        {
            projects.Add(project);
            await Task.CompletedTask;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var index = projects.FindIndex(existingProject => existingProject.Id == project.Id);
            projects[index] = project;
            await Task.CompletedTask;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            var index = projects.FindIndex(existingProject => existingProject.Id == id);
            projects.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}