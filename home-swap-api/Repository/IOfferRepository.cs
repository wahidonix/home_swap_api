using System;
using home_swap_api.Models;

namespace home_swap_api.Repository
{
	public interface IOfferRepository
	{
        Task<IEnumerable<Offer>> GetOffersAsync();
        void AddOffer(Offer offer);
        void DeleteOffer(int OfferId);
        Task<Offer> FindOffer(int id);
        Task<IEnumerable<Offer>> GetOffersByHouseIdAsync(int houseId);
        Task DeleteOffersByHouseIdAsync(int houseId);
      
    }
}

