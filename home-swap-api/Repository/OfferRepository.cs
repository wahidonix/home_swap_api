using System;
using home_swap_api.Data;
using home_swap_api.Models;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Repository
{
	public class OfferRepository : IOfferRepository
	{
        private readonly AppDbContext appDbContext;
        public OfferRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

        public void AddOffer(Offer offer)
        {
            appDbContext.Offers.AddAsync(offer);
        }

        public void DeleteOffer(int OfferId)
        {
            var offer = appDbContext.Offers.Find(OfferId);
            appDbContext.Offers.Remove(offer);
        }

        

        public async Task DeleteOffersByHouseIdAsync(int houseId)
        {
            var offersToDelete = await GetOffersByHouseIdAsync(houseId);
            appDbContext.Offers.RemoveRange(offersToDelete);
        }

        public async Task DeleteOffersByUserIdAsync(int userId)
        {
            var offersToDelete = await GetOffersByUserIdAsync(userId);
            appDbContext.Offers.RemoveRange(offersToDelete);
        }

        public async Task<Offer> FindOffer(int id)
        {
            return await appDbContext.Offers.FindAsync(id);
        }

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await appDbContext.Offers.ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByHouseIdAsync(int houseId)
        {
            return await appDbContext.Offers.Where(offer => offer.HouseId == houseId).ToListAsync();
        }

        public async Task<IEnumerable<Offer>> GetOffersByUserIdAsync(int userId)
        {
            return await appDbContext.Offers.Where(offer => offer.BuyerId == userId).ToListAsync();
        }
    }
}

