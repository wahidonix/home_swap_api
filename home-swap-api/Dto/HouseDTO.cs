using System;
using System.ComponentModel.DataAnnotations;

namespace home_swap_api.Dto
{
	public class HouseDTO
	{
        public int Id { get; set; }
        [Required (ErrorMessage ="Treba ti tip")]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int? Area { get; set; }
        [Required]
        public int Rooms { get; set; }
        [StringLength(3)]
        public string Garage { get; set; } = string.Empty;
        public bool IsBlocked { get; set; } = false;
        public bool IsSwapped { get; set; } = false;
        public int UserId { get; set; }

    }
}

