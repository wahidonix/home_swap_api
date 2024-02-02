using System;
using home_swap_api.Dto;
using home_swap_api.Models;
using MediatR;

namespace home_swap_api.Queries
{
	public class BlockHouseQuery : IRequest<House>
    {
        public int id { get; set; }
        public BlockHouseQuery(int id)
		{
			this.id = id;
		}
	}
}

