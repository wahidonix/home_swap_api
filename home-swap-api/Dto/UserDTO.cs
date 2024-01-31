using System;
namespace home_swap_api.Dto
{
	public class UserDTO
	{
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
    }
}

