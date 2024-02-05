using System;
using home_swap_api.Dto;
using MediatR;

namespace home_swap_api.Queries
{
	public class GetSingleHouseByIdQuery : IRequest<HouseDTO>
    {
        public int id { get; set; }
        public GetSingleHouseByIdQuery(int id)
        {
            this.id = id;
        }
    }
}

