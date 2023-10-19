using EventsLogger.Entities;

namespace EventsLogger.Repositories
{

    public class InMemEntryRepository : IEntryRepository
    {
        private readonly List<Entry> entrys = new()
        {
            new Entry
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
            new Entry
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
            new Entry
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
        
        public async Task<IEnumerable<Entry>> GetEntryAsync()
        {
            return await Task.FromResult(entrys);
        }

        public async Task<Entry> GetEntryAsync(Guid id)
        {
            var entry = entrys.SingleOrDefault(entry => entry.Id == id)!;
            return await Task.FromResult(entry);
        }

        public async Task CreateEntryAsync(Entry entry)
        {
            entrys.Add(entry);
            await Task.CompletedTask;
        }

        public async Task UpdateEntryAsync(Entry entry)
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