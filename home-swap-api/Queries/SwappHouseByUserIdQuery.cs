using System;
using home_swap_api.Models;
using MediatR;

namespace home_swap_api.Queries
{
	public class SwappHouseByUserIdQuery : IRequest<House>
    {
        public int userId { get; set; }
        public SwappHouseByUserIdQuery(int userId)
		{
			this.userId = userId;
		}
	}
}

