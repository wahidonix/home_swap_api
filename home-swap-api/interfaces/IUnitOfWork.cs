using System;
using home_swap_api.Repository;

namespace home_swap_api.interfaces
{
	public interface IUnitOfWork
	{
		IHouseRepository HouseRepository { get; }

		IOfferRepository OfferRepository { get; }
	
        Task<bool> SaveAsync();
	}
}

