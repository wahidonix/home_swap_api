using System;
using home_swap_api.Data;
using home_swap_api.interfaces;
using home_swap_api.Models;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Service.Impl
{
	public class UserServiceImpl : UserService
	{
        private static List<User> users = new List<User>
        {
            new User{Id = 1, Username = "Alen" , PasswordHash = "nesto"},
            new User{Id = 2, Username = "Second" , PasswordHash = "opala"},
        };

        private readonly AppDbContext appDbContext;
        private readonly IUnitOfWork uow;


        public UserServiceImpl(AppDbContext appDbContext,IUnitOfWork uow)
        {
            this.appDbContext = appDbContext;
            this.uow = uow;
        }

        public async Task<User> AddUser(User user)
        {
            appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> BlockUser(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            if (user is null)
                return null;
            user.IsBlocked = !user.IsBlocked;
           
            await appDbContext.SaveChangesAsync();
            

            return user;
        }

        

        public async Task<User?> DeleteUser(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            if (user is null)
                return null;

            appDbContext.Users.Remove(user);
            await appDbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await appDbContext.Users.ToListAsync();

            return users;
        }

        public async Task<User?> GetSingleUser(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            if (user is null)
                return null;

            return user;
        }

        public async Task<User?> GetUserByUsername(string username)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user is null)
                return null;

            return user;
        }

        public async Task<User?> UpdateUser(int id, User user)
        {
            var user1 = await appDbContext.Users.FindAsync(id);
            if (user1 is null)
                return null;
            user1.Username = user.Username;
            user1.PasswordHash = user.PasswordHash;
            await appDbContext.SaveChangesAsync();


            return user1;
        }
    }
}

