using System;
using System.ComponentModel.DataAnnotations;

namespace home_swap_api.Models
{
	public class House
	{
        public int Id { get; set; }
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int? Area { get; set; }
        [Required]
        public int? Rooms { get; set; }
        public string Garage { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        public bool IsSwapped { get; set; } = false;
        public int UserId { get; set; }



    }
}

