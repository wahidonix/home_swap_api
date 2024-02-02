using System;
using AutoMapper;
using home_swap_api.Data;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class GetHousesHandler : IRequestHandler<GetHousesQuery, List<HouseDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public GetHousesHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<List<HouseDTO>> Handle(GetHousesQuery request, CancellationToken cancellationToken)
        {
            var houses = await uow.HouseRepository.GetHousesAsync();
            var housesDTO = mapper.Map<IEnumerable<HouseDTO>>(houses);
            return (List<HouseDTO>)housesDTO;
        }
    }
}

