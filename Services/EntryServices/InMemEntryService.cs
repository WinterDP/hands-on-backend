using EventsLogger.Dtos;
using EventsLogger.Entities;

namespace EventsLogger.Services.EntryServices
{

    public class InMemEntryService : IEntryService
    {
        private readonly List<EntryDto> entrys = new()
        {
            new EntryDto
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Description = "Finish the columns.",
                Project = "Building 1",
                Manager = "Manager 1",
                Worker = "Worker 1",
                HasOwnerSeen = false,
                HasManagerSeen = false,
                Files = null
            },
            new EntryDto
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
            new EntryDto
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

        public async Task<IEnumerable<EntryDto>> GetEntriesAsync()
        {
            return await Task.FromResult(entrys);
        }

        public async Task<EntryDto> GetEntryAsync(Guid id)
        {
            var entry = entrys.SingleOrDefault(entry => entry.Id == id)!;
            return await Task.FromResult(entry);
        }

        public async Task CreateEntryAsync(CreateEntryDto entry)
        {
            entrys.Add(entry);
            await Task.CompletedTask;
        }

        public async Task UpdateEntryAsync(UpdateEntryDto entry)
        {
            var index = entrys.FindIndex(existingEntry => existingEntry.Id == entry.Id);
            entrys[index] = entry;
            await Task.CompletedTask;
        }

        public async Task DeleteEntryAsync(Guid id)
        {
            var index = entrys.FindIndex(existingEntry => existingEntry.Id == id);
            entrys.RemoveAt(index);
            await Task.CompletedTask;
        }
    }

}