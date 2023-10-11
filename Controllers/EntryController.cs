using EventsLogger;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using EventsLogger.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("api/entry")]
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
    }
}