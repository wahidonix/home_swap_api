using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class GetFilteredHousesHandler : IRequestHandler<GetFilteredHousesQuery, List<HouseDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public GetFilteredHousesHandler(IUnitOfWork uow,IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<HouseDTO>> Handle(GetFilteredHousesQuery request, CancellationToken cancellationToken)
        {
            var houses = await uow.HouseRepository.GetHousesAsync();
            if (!string.IsNullOrEmpty(request.FilterDTO.Type))
            {
                houses = houses.Where(house => house.Type == request.FilterDTO.Type).ToList();
            }
            if (!string.IsNullOrEmpty(request.FilterDTO.Garage))
            {
                houses = houses.Where(house => house.Garage == request.FilterDTO.Garage).ToList();
            }
            if (request.FilterDTO.Rooms.HasValue)
            {
                houses = houses.Where(house => house.Rooms == request.FilterDTO.Rooms.Value).ToList();
            }
            if (request.FilterDTO.MinArea.HasValue && request.FilterDTO.MaxArea.HasValue)
            {
                houses = houses
                    .Where(house => house.Area >= request.FilterDTO.MinArea.Value && house.Area <= request.FilterDTO.MaxArea.Value)
                    .ToList();
            }


            var housesDTO = mapper.Map<IEnumerable<HouseDTO>>(houses);
            return (List<HouseDTO>)housesDTO;
        }
    }
}

