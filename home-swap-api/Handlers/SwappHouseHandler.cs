using System;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class SwappHouseHandler : IRequestHandler<SwappHouseQuery, House>
    {
        private readonly IUnitOfWork uow;
        public SwappHouseHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<House> Handle(SwappHouseQuery request, CancellationToken cancellationToken)
        {
            var houseFromDb = await uow.HouseRepository.FindHouse(request.id);
            houseFromDb.IsSwapped = !houseFromDb.IsSwapped;
            await uow.SaveAsync();
            return houseFromDb;
        }
    }
}

