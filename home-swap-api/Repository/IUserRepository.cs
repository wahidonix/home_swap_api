using System;
using home_swap_api.Models;

namespace home_swap_api.Repository
{
	public interface IUserRepository
	{
        Task<IEnumerable<User>> GetUsersAsync();
        void AddUser(User user);
        void DeleteUser(int UserId);
        Task<User> FindUser(int id);
        Task<User> FindUserByUsername(string username);
        Task<User?> BlockUser(int id);
    }
}

