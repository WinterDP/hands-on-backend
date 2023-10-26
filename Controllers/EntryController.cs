using AutoMapper;
using EventsLogger.Dto.Entry;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventsLogger.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Entry")]
    [ApiController]
    public class EntryAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IEntryRepository _dbEntry;
        private readonly IMapper _mapper;

        public EntryAPIController(IEntryRepository dbEntry, IMapper mapper)
        {
            _mapper = mapper;
            _dbEntry = dbEntry;
            _response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEntries()
        {
            try
            {
                IEnumerable<Entry> EntryList = await _dbEntry.GetAllAsync();
                _response.Result = _mapper.Map<List<EntryDTO>>(EntryList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }



        [HttpGet("{id:guid}", Name = "GetEntry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetEntry(Guid id)
        {
            try
            {
                var Entry = await _dbEntry.GetAsync(u => u.Id == id);
                if (Entry == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<EntryDTO>(Entry);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateEntry([FromBody] CreateEntryDTO createEntryDTO)
        {
            try
            {
                if (createEntryDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                if (await _dbEntry.GetAsync(u => u.Id == createEntryDTO.WorkerId) != null)
                {
                    ModelState.AddModelError("CustomError", "User ID is Invalid!");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                if (await _dbEntry.GetAsync(u => u.Id == createEntryDTO.ProjectId) != null)
                {
                    ModelState.AddModelError("CustomError", "Project ID is Invalid!");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.Result = ModelState;
                    return BadRequest(_response);
                }
                Entry entry = _mapper.Map<Entry>(createEntryDTO);

                await _dbEntry.CreateAsync(entry);

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<EntryDTO>(entry);

                return CreatedAtRoute("GetEntry", new { id = entry.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:guid}", Name = "DeleteEntry")]
        public async Task<ActionResult<APIResponse>> DeleteEntry(Guid id)
        {
            try
            {

                var Entry = await _dbEntry.GetAsync(u => u.Id == id);
                if (Entry == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbEntry.RemoveAsync(Entry);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:guid}", Name = "UpdateEntry")]
        public async Task<ActionResult<APIResponse>> UpdateEntry(Guid id, [FromBody] UpdateEntryDTO updateDTO)
        {
            try
            {

                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Entry model = _mapper.Map<Entry>(updateDTO);

                await _dbEntry.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch("{id:guid}", Name = "UpdatePartialEntry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialEntry(Guid id, JsonPatchDocument<UpdateEntryDTO> patchDTO)
        {
            try
            {

                var entry = await _dbEntry.GetAsync(u => u.Id == id, false);

                if (entry is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                UpdateEntryDTO EntryDTO = _mapper.Map<UpdateEntryDTO>(entry);

                patchDTO.ApplyTo(EntryDTO, ModelState);

                Entry model = _mapper.Map<Entry>(EntryDTO);
                model.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);

                await _dbEntry.UpdateAsync(model);

                if (!ModelState.IsValid)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

    }
}