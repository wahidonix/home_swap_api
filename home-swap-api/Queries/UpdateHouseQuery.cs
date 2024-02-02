using System;
using home_swap_api.Dto;
using MediatR;

namespace home_swap_api.Queries
{
	public class UpdateHouseQuery : IRequest<HouseDTO>
    {
        public HouseDTO HouseDTO { get; set; }
        public int id { get; set; }
        public UpdateHouseQuery(int id, HouseDTO HouseDTO)
        {
            this.id = id;
            this.HouseDTO = HouseDTO;
        }
    }
}

