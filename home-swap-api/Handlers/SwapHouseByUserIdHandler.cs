using System;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
	public class SwapHouseByUserIdHandler : IRequestHandler<SwappHouseByUserIdQuery, House>
    {
        private readonly IUnitOfWork uow;
        public SwapHouseByUserIdHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
       

        public async Task<House> Handle(SwappHouseByUserIdQuery request, CancellationToken cancellationToken)
        {
            var houseFromDb = await uow.HouseRepository.FindHouseByUserId(request.userId);
            houseFromDb.IsSwapped = !houseFromDb.IsSwapped;
            await uow.SaveAsync();
            return houseFromDb;
        }
    }
}

