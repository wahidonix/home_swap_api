using System;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class BlockHouseHandler : IRequestHandler<BlockHouseQuery, House>
    {
        private readonly IUnitOfWork uow;
        public BlockHouseHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<House> Handle(BlockHouseQuery request, CancellationToken cancellationToken)
        {
            var houseFromDb = await uow.HouseRepository.FindHouse(request.id);
            houseFromDb.IsBlocked = !houseFromDb.IsBlocked;
            await uow.SaveAsync();
            if (houseFromDb.IsBlocked)
            {
                // Delete offers associated with the blocked house
                await uow.OfferRepository.DeleteOffersByHouseIdAsync(request.id);
                await uow.SaveAsync();
            }

            return houseFromDb;
        }
    }
}

