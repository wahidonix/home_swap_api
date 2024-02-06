using System;
namespace home_swap_api.Models
{
	public class User
	{
		public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
		public bool IsBlocked { get; set; } = false;
        public DateTime? DateBlocked { get; set; }
		public string Blocked { get; set; }
        public User()
		{
		}
	}
}

