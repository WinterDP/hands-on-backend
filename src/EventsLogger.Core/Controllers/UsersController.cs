using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using EventsLogger.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace EventsLogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<IEnumerable<UserDto>>>> Get()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetSingle(Guid id)
        {
            return Ok(await _userService.GetUserAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ServiceResponse<UserDto>>>> CreateUser(CreateUserDto newUser)
        {
            return Ok(await _userService.CreateUserAsync(newUser));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ServiceResponse<UserDto>>>> UpdateUser(UpdateUserDto updatedUser)
        {
            var response = await _userService.UpdateUserAsync(updatedUser);
            if (response is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> DeleteUser(Guid id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (response is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}