using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class UpdateHouseHandler : IRequestHandler<UpdateHouseQuery, HouseDTO>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;
        public UpdateHouseHandler(IMapper mapper,IUnitOfWork uow)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<HouseDTO> Handle(UpdateHouseQuery request, CancellationToken cancellationToken)
        {
            var houseFromDb = await uow.HouseRepository.FindHouse(request.id);
            mapper.Map(request.HouseDTO, houseFromDb);
            houseFromDb.Id = request.id;
            await uow.SaveAsync();
            return request.HouseDTO;
        }
    }
}

