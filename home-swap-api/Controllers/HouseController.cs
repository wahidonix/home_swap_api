using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using home_swap_api.Data;
using home_swap_api.Dto;
using home_swap_api.interfaces;
using home_swap_api.Models;
using home_swap_api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {

        private readonly IMediator mediator;

        public HouseController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetHouses()
        {
            var query = new GetHousesQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("available-houses")]
        public async Task<IActionResult> GetAvailableHouses()
        {
            var query = new GetAvailableHousesQuery();
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("signle-house/{userId}")]
        public async Task<IActionResult> GetSingleHouse(int userId)
        {
            var query = new GetSingleHouseQuery(userId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("signle-house-by-id/{id}")]
        public async Task<IActionResult> GetSingleHouseById(int id)
        {
            var query = new GetSingleHouseByIdQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddHouse([FromBody] HouseDTO houseDTO)
        {
            var query = new AddHouseQuery { HouseDTO = houseDTO };
            var result = await mediator.Send(query);

            return Ok(result);
           
        }

        [HttpPut("blocked-status/{id}")]
        public async Task<IActionResult> BlockHouse(int id)
        {
            var query = new BlockHouseQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("swapped-status/{id}")]
        public async Task<IActionResult> SwapHouse(int id)
        {
            var query = new SwappHouseQuery(id);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPut("swapped-status-by-userId/{userId}")]
        public async Task<IActionResult> SwapHouseByUserId(int userId)
        {
            var query = new SwappHouseByUserIdQuery(userId);
            var result = await mediator.Send(query);

            return Ok(result);
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var query = new DeleteHouseQuery(id);
            var result = await mediator.Send(query);

            return Ok(id);
           
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateHouse(int id, HouseDTO houseDTO)
        {
            var query = new UpdateHouseQuery(id, houseDTO);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        

        [HttpPost("filtered-houses")]
        public async Task<IActionResult> GetFilteredHouses([FromBody] FilterDTO filterDTO)
        {
            var query = new GetFilteredHousesQuery(filterDTO);
            var result = await mediator.Send(query);

            return Ok(result);
        }



    }
}