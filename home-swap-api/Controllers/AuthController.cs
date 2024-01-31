using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace home_swap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


 
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork uow;

        public AuthController(IConfiguration configuration, IUnitOfWork uow)
        {
         
            this.configuration = configuration;
            this.uow = uow;
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register([FromBody] UserDTO userDTO)
        {
            var user = new User();
            var existingUser = await uow.UserRepository.FindUserByUsername(userDTO.Username);
            if (existingUser is not null)
                return BadRequest("username already taken");
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

            user.Username = userDTO.Username;
            user.PasswordHash = passwordHash;
            user.Role = "User";
            user.IsBlocked = false;
            uow.UserRepository.AddUser(user);
            await uow.SaveAsync();

            //var authResponseDTO = new AuthResponseDTO();
            //authResponseDTO.Username = user.Username;
            //authResponseDTO.Id = user.Id;
            //authResponseDTO.Role = user.Role;

            //string token = CreateToken(authResponseDTO);
            //authResponseDTO.Token = token;

            return Ok("user created!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDTO>> Login([FromBody] UserDTO userDTO)
        {
            var result = await uow.UserRepository.FindUserByUsername(userDTO.Username);
            if (result is null)
                return BadRequest("user not found");

            if (!BCrypt.Net.BCrypt.Verify(userDTO.Password, result.PasswordHash))
            {
                return BadRequest("wrong password");
            }

            var authResponseDTO = new AuthResponseDTO();
            authResponseDTO.Username = result.Username;
            authResponseDTO.Id = result.Id;
            authResponseDTO.Role = result.Role;

            string token = CreateToken(authResponseDTO);
            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken,authResponseDTO);

            authResponseDTO.Token = token;

            return Ok(authResponseDTO);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDTO authResponseDTO)
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (!authResponseDTO.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token");
            }
            else if (authResponseDTO.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired");
            }

            string token = CreateToken(authResponseDTO);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken, authResponseDTO);

            return Ok(new { Token = token, RefreshToken = newRefreshToken.Token });
        }


        private RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7)
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken,AuthResponseDTO authResponseDTO)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };
            Response.Cookies.Append("refreshToken", newRefreshToken.Token,cookieOptions);
            authResponseDTO.RefreshToken = newRefreshToken.Token;
            authResponseDTO.TokenCreated = newRefreshToken.Created;
            authResponseDTO.TokenExpires = newRefreshToken.Expires;

        }

        private string CreateToken(AuthResponseDTO authResponseDTO)
        {


            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,authResponseDTO.Id.ToString()),
                new Claim(ClaimTypes.Role, authResponseDTO.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


    }
}
