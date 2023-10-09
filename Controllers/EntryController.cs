using Entries.Model;
using Microsoft.AspNetCore.Mvc;

namespace entriesCL.Controllers
{
    [ApiController]
    [Route("api/entries")]
    public class EntriesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetEntries()
        {
            DateTime now = DateTime.Now;
            Entry newEntry = new(
                description: "this is a boilerplate entry, it only exists to make the Controller!",
                project: "boilerplate Project",
                manager: "boilerplate Manager",
                worker: "boilerplate Worker");

            return Ok(newEntry);
        }
    }
}