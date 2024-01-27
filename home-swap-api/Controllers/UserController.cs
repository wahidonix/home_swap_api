using System;
using home_swap_api.Dto;
using home_swap_api.Models;
using home_swap_api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace home_swap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }

        [HttpGet("(id)")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var result = await userService.GetSingleUser(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }
        [HttpGet("check-user/(username)")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var result = await userService.GetUserByUsername(username);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var result = await userService.AddUser(user);

            return Ok(result);
        }

        [HttpPut("(id)")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            var result = await userService.UpdateUser(id, user);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var result = await userService.DeleteUser(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPut("blocked-status/(id)"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> BlockUser(int id)
        {
            var result = await userService.BlockUser(id);
            if (result is null)
                return NotFound("User not found");

            return Ok(result);


        }



    }
}
