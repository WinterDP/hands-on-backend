using Entries.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

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
            Entry newEntry = new("this is a boilerplate entry, it only exists to make the Controller!", "boilerplate Project", "boilerplate Manager", "boilerplate Worker")
            {
                TimeStamp = DateTime.Now,
                HasManagerSeen = false,
                HasOwnerSeen = false
            };

            return Ok(newEntry);
        }
    }
}