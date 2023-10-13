using EventsLogger;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using EventsLogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("entry")]
    public class EntryController : ControllerBase
    {
        private readonly InMemEntryRepository repository;

        public EntryController()
        {
            this.repository = new InMemEntryRepository();
        }

        // GET /entry/
        [HttpGet]
        public async Task<IEnumerable<EntryDto>> GetEntryAsync()
        {
            var entry = (await repository.GetEntryAsync())
                        .Select(entry => entry.AsDto());
            return entry;
        }
        // GET /entry/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EntryDto>> GetEntryAsync(Guid id)
        {
            var entry = await repository.GetEntryAsync(id);

            if (entry is null)
            {
                return NotFound();
            }

            return entry.AsDto();
        }
        // POST /entry/
        [HttpPost]
        public async Task<ActionResult<EntryDto>> CreateEntryAsync(CreateEntryDto entryDto)
        {
            Entry entry = new()
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Description = entryDto.Description,
                Project = entryDto.Project,
                Manager = entryDto.Manager,
                Worker = entryDto.Worker,
                HasOwnerSeen = false,
                HasManagerSeen = false,
                Files = entryDto.Files
            };

            await repository.CreateEntryAsync(entry);

            return CreatedAtAction(nameof(GetEntryAsync), new { id = entry.Id }, entry.AsDto());
        }
        // PUT /entry/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEntryAsync(Guid id, UpdateEntryDto entryDto)
        {
            var existingEntry = await repository.GetEntryAsync(id);
            if (existingEntry is null)
            {
                return NotFound();
            }
            Entry updatedEntry = existingEntry with
            {
                Description = entryDto.Description,
                Project = entryDto.Project,
                Manager = entryDto.Manager,
                Worker = entryDto.Worker,
            };
            await repository.UpdateEntryAsync(updatedEntry);

            return NoContent();
        }

        // DELETE /entry/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEntryAsync(Guid id)
        {
            var existingEntry = await repository.GetEntryAsync(id);
            if (existingEntry is null)
            {
                return NotFound();
            }
            await repository.DeleteEntryAsync(id);

            return NoContent();

        }

    }
}