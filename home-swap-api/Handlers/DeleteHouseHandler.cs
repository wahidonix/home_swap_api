using System;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class DeleteHouseHandler : IRequestHandler<DeleteHouseQuery, int>
    {
        private readonly IUnitOfWork uow;
        public DeleteHouseHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public async Task<int> Handle(DeleteHouseQuery request, CancellationToken cancellationToken)
        {
            uow.HouseRepository.DeleteHouse(request.id);
            await uow.SaveAsync();

            return request.id;
        }
    }
}

