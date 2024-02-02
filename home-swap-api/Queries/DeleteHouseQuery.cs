using System;
using MediatR;

namespace home_swap_api.Queries
{
	public class DeleteHouseQuery : IRequest<int>
	{
		public int id { get; set; }
		public DeleteHouseQuery(int id)
		{
            this.id = id;
        }
	}
}

