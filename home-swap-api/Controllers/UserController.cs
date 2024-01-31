using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Repository;
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
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UserController(UserService userService , IUnitOfWork uow, IMapper mapper)
        {
            this.userService = userService;
            this.uow = uow;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await userService.GetAllUsers();
        }

        [HttpGet("new-get")]
        public async Task<IActionResult> NewGetAllUsers()
        {
            var users = await uow.UserRepository.GetUsersAsync();
            var usersDTO = mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersDTO);
        }

        [HttpGet("(id)")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var result = await userService.GetSingleUser(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpGet("new-get-by-id/(id)")]
        public async Task<ActionResult<User>> NewGetSingleUser(int id)
        {
            var userFromDb = await uow.UserRepository.FindUser(id);
            if (userFromDb is null)
                return NotFound("user not found");

          
            return Ok(userFromDb);
        }


        [HttpGet("check-user/(username)")]
        public async Task<ActionResult<User>> GetUserByUsername(string username)
        {
            var result = await userService.GetUserByUsername(username);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpGet("new-check-user/(username)")]
        public async Task<ActionResult<User>> NewGetUserByUsername(string username)
        {
            var result = await uow.UserRepository.FindUserByUsername(username);
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

        [HttpPost("new-post")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            //throw new UnauthorizedAccessException();
            var user = mapper.Map<User>(userDTO);


            uow.UserRepository.AddUser(user);
            await uow.SaveAsync();

            return StatusCode(201);
        }

        [HttpPut("(id)")]
        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            var result = await userService.UpdateUser(id, user);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpPut("new-update(id)")]
        public async Task<ActionResult<User>> NewUpdateUser(int id, [FromBody] UserDTO userDTO)
        {
            var userFromDb = await uow.UserRepository.FindUser(id);
            mapper.Map(userDTO, userFromDb);
            userFromDb.Id = id;
            await uow.SaveAsync();

            return StatusCode(200);
        }

        [HttpDelete("(id)")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var result = await userService.DeleteUser(id);
            if (result is null)
                return NotFound("user not found");

            return Ok(result);
        }

        [HttpDelete("new-delete/{id}")]
        public async Task<IActionResult> NewDeleteUser(int id)
        {
            uow.UserRepository.DeleteUser(id);
            await uow.SaveAsync();

            return Ok(id);
        }

        [HttpPut("blocked-status/(id)"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> BlockUser(int id)
        {
            var result = await userService.BlockUser(id);
            if (result is null)
                return NotFound("User not found");

            if (result.IsBlocked)
            {
                await uow.OfferRepository.DeleteOffersByUserIdAsync(id);
                await uow.SaveAsync();
            }


            return Ok(result);

        }

        [HttpPut("new-blocked-status/(id)")]
        public async Task<ActionResult<User>> NewBlockUser(int id)
        {
            var result = await uow.UserRepository.BlockUser(id);
            if (result is null)
                return NotFound("User not found");

            if (result.IsBlocked)
            {
                await uow.OfferRepository.DeleteOffersByUserIdAsync(id);
                await uow.SaveAsync();
            }


            return Ok(result);

        }





    }
}