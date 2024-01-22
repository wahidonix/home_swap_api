using System;
using home_swap_api.Models;

namespace home_swap_api.Service
{
    public interface UserService
	{
		Task<List<User>> GetAllUsers();
		Task<User?> GetSingleUser(int id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(int id,User user);
        Task<User?> DeleteUser(int id);

    }
}

