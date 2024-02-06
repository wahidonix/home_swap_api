using System;
namespace home_swap_api.Models
{
	public class Image
	{
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int HouseId { get; set; }
        
		
	}
}

