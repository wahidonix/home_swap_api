using System;
using home_swap_api.Dto;
using MediatR;

namespace home_swap_api.Queries
{
	public class GetSingleHouseQuery : IRequest<HouseDTO>
    {
        public int userId { get; set; }
        public GetSingleHouseQuery(int userId)
		{
			this.userId = userId;
		}
	}
}

