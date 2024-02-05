using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
	public class GetSingleHouseByIdHandler : IRequestHandler<GetSingleHouseByIdQuery, HouseDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public GetSingleHouseByIdHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<HouseDTO> Handle(GetSingleHouseByIdQuery request, CancellationToken cancellationToken)
        {
            var houseFromDb = await uow.HouseRepository.FindHouse(request.id);
            var houseDto = mapper.Map<HouseDTO>(houseFromDb);
            return houseDto;
        }
    }
}

