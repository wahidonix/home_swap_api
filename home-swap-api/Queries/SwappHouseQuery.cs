using System;
using home_swap_api.Models;
using MediatR;

namespace home_swap_api.Queries
{
	public class SwappHouseQuery : IRequest<House>
    {
        public int id { get; set; }
        public SwappHouseQuery(int id)
		{
			this.id = id;
		}
	}
}

