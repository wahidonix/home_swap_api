using System;
namespace home_swap_api.Models
{
	public class Offer
	{
        public int Id { get; set; }
		public string Payment { get; set; } = string.Empty;
		public int BuyerId { get; set; }
		public int? HouseId { get; set; } = 0;
		public string Status { get; set; } = "Pending";
        public Offer()
		{
		
		}
	}
}

