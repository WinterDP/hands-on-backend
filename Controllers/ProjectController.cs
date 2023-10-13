using EventsLogger;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using EventsLogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("project")]
    public class ProjectController : ControllerBase
    {
        private readonly InMemProjectRepository repository;

        public ProjectController()
        {
            this.repository = new InMemProjectRepository();
        }

        // GET /project/
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> GetProjectAsync()
        {
            var project = (await repository.GetProjectAsync())
                        .Select(project => project.AsDto());
            return project;
        }
        // GET /project/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectAsync(Guid id)
        {
            var project = await repository.GetProjectAsync(id);

            if (project is null)
            {
                return NotFound();
            }

            return project.AsDto();
        }
        // POST /project/
        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProjectAsync(CreateProjectDto projectDto)
        {
            Project project = new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Description = projectDto.Description,
                Project = projectDto.Project,
                Manager = projectDto.Manager,
                Worker = projectDto.Worker,
                HasOwnerSeen = false,
                HasManagerSeen = false,
                Files = projectDto.Files
            };

            await repository.CreateProjectAsync(project);

            return CreatedAtAction(nameof(GetProjectAsync), new { id = project.Id }, project.AsDto());
        }
        // PUT /project/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProjectAsync(Guid id, UpdateProjectDto projectDto)
        {
            var existingProject = await repository.GetProjectAsync(id);
            if (existingProject is null)
            {
                return NotFound();
            }
            Project updatedProject = existingProject with
            {
                Description = projectDto.Description,
                Project = projectDto.Project,
                Manager = projectDto.Manager,
                Worker = projectDto.Worker,
            };
            await repository.UpdateProjectAsync(updatedProject);

            return NoContent();
        }

        // DELETE /project/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjectAsync(Guid id)
        {
            var existingProject = await repository.GetProjectAsync(id);
            if (existingProject is null)
            {
                return NotFound();
            }
            await repository.DeleteProjectAsync(id);

            return NoContent();

        }

    }
}