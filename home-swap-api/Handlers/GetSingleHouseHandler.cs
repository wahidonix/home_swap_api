using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class GetSingleHouseHandler : IRequestHandler<GetSingleHouseQuery, HouseDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public GetSingleHouseHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<HouseDTO> Handle(GetSingleHouseQuery request, CancellationToken cancellationToken)
        {
            var userId = request.userId;
            var houseFromDb = await uow.HouseRepository.FindHouseByUserId(userId);
            var houseDto = mapper.Map<HouseDTO>(houseFromDb);
            return houseDto;

        }
    }
}

