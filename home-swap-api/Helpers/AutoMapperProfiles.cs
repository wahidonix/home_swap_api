using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.Models;

namespace home_swap_api.Helpers
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<House, HouseDTO>();
			CreateMap<House, HouseDTO>().ReverseMap();

            CreateMap<House, HouseUpdateDTO>();
            CreateMap<House, HouseUpdateDTO>().ReverseMap();
        }
	}
}

