using System;
using AutoMapper;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;

namespace home_swap_api.Handlers
{
    public class AddHouseHandler : IRequestHandler<AddHouseQuery, string>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public AddHouseHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<string> Handle(AddHouseQuery request, CancellationToken cancellationToken)
        {
            var house = mapper.Map<House>(request.HouseDTO);
            uow.HouseRepository.AddHouse(house);
            await uow.SaveAsync();

            return "house added!";
        }
    }
}

