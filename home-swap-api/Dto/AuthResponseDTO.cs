using System;
namespace home_swap_api.Dto
{
	public class AuthResponseDTO
	{
        public string Token { get; set; } = string.Empty;
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }


        public AuthResponseDTO()
		{
		}
	}
}

