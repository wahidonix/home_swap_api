using System;
using home_swap_api.Data;
using home_swap_api.Models;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Repository
{
	public class UserRepository : IUserRepository
	{
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
		}

        public void AddUser(User user)
        {
            appDbContext.Users.AddAsync(user);
        }

        public async Task<User?> BlockUser(int id)
        {
            var user = appDbContext.Users.Find(id);
            if (user is null)
                return null;

            user.IsBlocked = !user.IsBlocked;
            await appDbContext.SaveChangesAsync();


            return user;
        }

        public void DeleteUser(int UserId)
        {
            var user = appDbContext.Users.Find(UserId);
            appDbContext.Users.Remove(user);
        }

        public async Task<User> FindUser(int id)
        {
            return await appDbContext.Users.FindAsync(id);
        }

        public async Task<User> FindUserByUsername(string username)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await appDbContext.Users.ToListAsync();
        }
    }
}

