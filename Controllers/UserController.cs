using AutoMapper;
using EventsLogger.Dto.User;
using EventsLogger.Entities;
using EventsLogger.Repositories.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventsLogger.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/User")]
    [ApiController]
    public class UserAPIController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IUserRepository _dbUser;
        private readonly IMapper _mapper;

        public UserAPIController(IUserRepository dbUser, IMapper mapper)
        {
            _mapper = mapper;
            _dbUser = dbUser;
            _response = new();
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetEntries()
        {
            try
            {
                IEnumerable<User> UserList = await _dbUser.GetAllAsync();
                _response.Result = _mapper.Map<List<UserDTO>>(UserList);
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



        [HttpGet("{id:guid}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetUser(Guid id)
        {
            try
            {
                var User = await _dbUser.GetAsync(u => u.Id == id);
                if (User == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = _mapper.Map<UserDTO>(User);
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
        public async Task<ActionResult<APIResponse>> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            try
            {
                if (createUserDTO == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                User user = _mapper.Map<User>(createUserDTO);

                // Default Parameters
                user.CreatedDate = DateTime.UtcNow;
                user.Role = "worker";

                await _dbUser.CreateAsync(user);

                _response.StatusCode = HttpStatusCode.Created;
                _response.Result = _mapper.Map<UserDTO>(user);

                return CreatedAtRoute("GetUser", new { id = user.Id }, _response);
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
        [HttpDelete("{id:guid}", Name = "DeleteUser")]
        public async Task<ActionResult<APIResponse>> DeleteUser(Guid id)
        {
            try
            {

                var User = await _dbUser.GetAsync(u => u.Id == id);
                if (User == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                await _dbUser.RemoveAsync(User);

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
        [HttpPut("{id:guid}", Name = "UpdateUser")]
        public async Task<ActionResult<APIResponse>> UpdateUser(Guid id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            try
            {

                if (updateUserDTO == null || id != updateUserDTO.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                User user = _mapper.Map<User>(updateUserDTO);

                await _dbUser.UpdateAsync(user);
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

        [HttpPatch("{id:guid}", Name = "UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialUser(Guid id, JsonPatchDocument<UpdateUserDTO> patchDTO)
        {
            try
            {

                var User = await _dbUser.GetAsync(u => u.Id == id, false);

                if (User is null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                UpdateUserDTO UserDTO = _mapper.Map<UpdateUserDTO>(User);

                patchDTO.ApplyTo(UserDTO, ModelState);

                User model = _mapper.Map<User>(UserDTO);

                await _dbUser.UpdateAsync(model);

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