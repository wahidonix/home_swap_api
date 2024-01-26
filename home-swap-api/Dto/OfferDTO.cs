using System;
namespace home_swap_api.Dto
{
	public class OfferDTO
	{
        public int Id { get; set; }
        public string Payment { get; set; }
        public int BuyerId { get; set; }
        public int? HouseId { get; set; } = 0;
        public OfferDTO()
		{
		}
	}
}

