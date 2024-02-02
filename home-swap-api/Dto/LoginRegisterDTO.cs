using System;
namespace home_swap_api.Dto
{
	public class LoginRegisterDTO
	{
        public required string Username { get; set; }
        public required string Password { get; set; }
        public LoginRegisterDTO()
		{
		}
	}
}

