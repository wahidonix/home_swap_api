using System;
using home_swap_api.Models;

namespace home_swap_api.Repository
{
	public interface IHouseRepository
	{
		Task<IEnumerable<House>> GetHousesAsync();
		void AddHouse(House house);
		void DeleteHouse(int HouseId);
		Task<House> FindHouse(int id);
		Task<House> FindHouseByUserId(int userId);
	}
}

