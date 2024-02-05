using System;
using home_swap_api.Data;
using home_swap_api.Models;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Repository
{
	public class HouseRepository : IHouseRepository
	{
        private readonly AppDbContext appDbContext;

		public HouseRepository(AppDbContext appDbContext)
		{
            this.appDbContext = appDbContext;
		}

        public void AddHouse(House house)
        {
            appDbContext.Houses.AddAsync(house);
        }

        public void DeleteHouse(int HouseId)
        {
            var house = appDbContext.Houses.Find(HouseId);
            appDbContext.Houses.Remove(house);

        }

        public async Task<House> FindHouse(int id)
        {
            return await appDbContext.Houses.FindAsync(id);
        }

        public async Task<House> FindHouseByUserId(int userId)
        {
            return await appDbContext.Houses.FirstOrDefaultAsync(house => house.UserId == userId);
        }

        public async Task<IEnumerable<House>> GetHousesAsync()
        {
            return await appDbContext.Houses.ToListAsync();
        }

    }
}

