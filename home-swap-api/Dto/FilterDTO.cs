using System;
namespace home_swap_api.Dto
{
	public class FilterDTO
	{
		
        public string Type { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public int? Rooms { get; set; }
        public string Garage { get; set; } = string.Empty;
        public int? MinArea { get; set; }
        public int? MaxArea { get; set; }
        public FilterDTO() { }
    }
}

