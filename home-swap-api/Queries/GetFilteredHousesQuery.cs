using System;
using home_swap_api.Dto;
using MediatR;

namespace home_swap_api.Queries
{
	public class GetFilteredHousesQuery : IRequest<List<HouseDTO>>
    {
        public FilterDTO FilterDTO { get; set; }
        public GetFilteredHousesQuery(FilterDTO FilterDTO)
        {
            this.FilterDTO = FilterDTO;
        }
    }
}

