using EventsLogger.Dtos;
using EventsLogger.Services.EntryServices;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly EntryService repository;

        public EntryController()
        {
            this.repository = new EntryService();
        }

        // GET /entry/
        [HttpGet]
        public async Task<IEnumerable<EntryDto>> GetEntryAsync()
        {
            var entry = (await repository.GetEntriesAsync())
                        .Select(entry => entry.AsDto());
            return entry;
        }
    }
}