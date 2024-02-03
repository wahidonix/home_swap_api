using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class GetAvailableHousesHandler : IRequestHandler<GetAvailableHousesQuery, List<HouseDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public GetAvailableHousesHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<HouseDTO>> Handle(GetAvailableHousesQuery request, CancellationToken cancellationToken)
        {
            var houses = await uow.HouseRepository.GetHousesAsync();
            houses = houses.Where(house => !house.IsBlocked).ToList();
            houses = houses.Where(house => !house.IsSwapped).ToList();
            var housesDTO = mapper.Map<IEnumerable<HouseDTO>>(houses);
            return (List<HouseDTO>)housesDTO;
        }
    }
}

