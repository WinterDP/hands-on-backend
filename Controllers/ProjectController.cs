using AutoMapper;
using EventsLogger.Dto.Address;
using EventsLogger.Dto.Project;
using EventsLogger.Dto.RelationshipProjectUser;
using EventsLogger.Entities;
using EventsLogger.Maps;
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
        private readonly IRelationshipProjectUserRepository _dbRelationship;
        private readonly IAddressRepository _dbAddress;
        private readonly IUserRepository _dbUser;
        private readonly IMapper _mapper;

        public ProjectAPIController(IProjectRepository dbProject, IMapper mapper, IRelationshipProjectUserRepository dbRelationship, IAddressRepository dbAddress, IUserRepository dbUser)
        {
            _mapper = mapper;
            _dbProject = dbProject;
            _response = new();
            _dbRelationship = dbRelationship;
            _dbAddress = dbAddress;
            _dbUser = dbUser;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetProjects()
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

        [HttpPost("AddUser/{id:guid}", Name = "AddUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> AddUser(Guid id, [FromBody] CreateRelationshipProjectUsersDTO createRelationshipProjectUserDTO)
        {
            try
            {
                var project = await _dbProject.GetAsync(u => u.Id == id);
                if (project == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                RelationshipProjectUsers relationship = _mapper.Map<RelationshipProjectUsers>(createRelationshipProjectUserDTO);
                await _dbRelationship.CreateAsync(relationship);

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<RelationshipProjectUsersDTO>(relationship);

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
                var project = await _dbProject.GetAsync(u => u.Id == id);

                var address = await _dbAddress.GetAsync(u => u.Id == project.AddressId);


                AddressDTO addressDTO = new()
                {
                    Id = address.Id,
                    City = address.City,
                    State = address.State,
                    Street = address.Street,
                    ZipCode = address.ZipCode,
                    Country = address.Country,
                };

                ProjectDTO projectDTO = new()
                {
                    CreatedDate = project.CreatedDate,
                    UpdatedDate = project.UpdatedDate,
                    Id = project.Id,
                    Name = project.Name,
                    Address = addressDTO,
                    AddressId = address.Id,
                    CreatorId = project.CreatorId
                };

                if (project == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = projectDTO;
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

                var user = await _dbUser.GetAsync(u => u.Id == createProjectDTO.CreatorId);


                Address address = new()
                {
                    Id = Guid.NewGuid(),
                    State = createProjectDTO.Address.State,
                    Street = createProjectDTO.Address.Street,
                    City = createProjectDTO.Address.City,
                    ZipCode = createProjectDTO.Address.ZipCode,
                    Country = createProjectDTO.Address.Country,
                };
                await _dbAddress.CreateAsync(address);


                Project project = new()
                {
                    Id = Guid.NewGuid(),
                    Name = createProjectDTO.Name,
                    CreatedDate = DateTime.UtcNow,
                    CreatorId = user.Id,
                    Address = address,
                    AddressId = address.Id,
                    Creator = user,
                };
                await _dbProject.CreateAsync(project);


                AddressDTO addressDTO = new()
                {
                    Id = address.Id,
                    City = address.City,
                    State = address.State,
                    Street = address.Street,
                    ZipCode = address.ZipCode,
                    Country = address.Country,
                };

                ProjectDTO projectDTO = new()
                {
                    CreatedDate = project.CreatedDate,
                    UpdatedDate = project.UpdatedDate,
                    Id = project.Id,
                    Name = project.Name,
                    Address = addressDTO,
                    AddressId = addressDTO.Id,
                    CreatorId = project.CreatorId
                };


                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = projectDTO;

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