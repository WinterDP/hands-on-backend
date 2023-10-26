using AutoMapper;
using EventsLogger.Dto.Project;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventsLogger.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Project")]
    [ApiController]
    public class ProjectAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IProjectRepository _dbProject;
        private readonly IMapper _mapper;

        public ProjectAPIController(IProjectRepository dbProject, IMapper mapper)
        {
            _mapper = mapper;
            _dbProject = dbProject;
            _response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEntries()
        {
            try
            {
                IEnumerable<Project> ProjectList = await _dbProject.GetAllAsync();
                _response.Result = _mapper.Map<List<ProjectDTO>>(ProjectList);
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



        [HttpGet("{id:guid}", Name = "GetProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetProject(Guid id)
        {
            try
            {
                var Project = await _dbProject.GetAsync(u => u.Id == id);
                if (Project == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<ProjectDTO>(Project);
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
        public async Task<ActionResult<APIResponse>> CreateProject([FromBody] CreateProjectDTO createProjectDTO)
        {
            try
            {
                if (createProjectDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Project project = _mapper.Map<Project>(createProjectDTO);


                await _dbProject.CreateAsync(project);

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<ProjectDTO>(project);

                return CreatedAtRoute("GetProject", new { id = project.Id }, _response);
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
        [HttpDelete("{id:guid}", Name = "DeleteProject")]
        public async Task<ActionResult<APIResponse>> DeleteProject(Guid id)
        {
            try
            {

                var Project = await _dbProject.GetAsync(u => u.Id == id);
                if (Project == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbProject.RemoveAsync(Project);

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
        [HttpPut("{id:guid}", Name = "UpdateProject")]
        public async Task<ActionResult<APIResponse>> UpdateProject(Guid id, [FromBody] UpdateProjectDTO updateDTO)
        {
            try
            {

                if (updateDTO == null || id != updateDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Project project = _mapper.Map<Project>(updateDTO);

                await _dbProject.UpdateAsync(project);
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

        [HttpPatch("{id:guid}", Name = "UpdatePartialProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialProject(Guid id, JsonPatchDocument<UpdateProjectDTO> patchDTO)
        {
            try
            {

                var project = await _dbProject.GetAsync(u => u.Id == id, false);

                if (project is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                UpdateProjectDTO projectDTO = _mapper.Map<UpdateProjectDTO>(project);

                patchDTO.ApplyTo(projectDTO, ModelState);

                Project model = _mapper.Map<Project>(projectDTO);

                await _dbProject.UpdateAsync(model);

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