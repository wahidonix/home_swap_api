using System;
using home_swap_api.Dto;
using MediatR;

namespace home_swap_api.Queries
{
	public class GetHousesQuery : IRequest<List<HouseDTO>>
	{
		
	}
}

