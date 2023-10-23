using EventsLogger.Dtos;
using EventsLogger.Services.EntryServices;
using Microsoft.AspNetCore.Mvc;
using EventsLogger;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService _repository;

        public EntryController(IEntryService entryService)
        {
            _repository = entryService;
        }

        // GET /entry/
        [HttpGet]
        public async Task<IEnumerable<EntryDto>> GetEntryAsync()
        {
            var entry = (await _repository.GetEntriesAsync())
                        .Select(entry => entry.AsDto());
            return entry;
        }
    }
}