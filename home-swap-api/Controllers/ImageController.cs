using System;
using home_swap_api.Data;
using home_swap_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace home_swap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
	{
        private readonly AppDbContext appDbContext;
        public ImageController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost("{houseId}")]
        public async Task<IActionResult> UploadImage(IFormFile file,int houseId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var image = new Image
                {
                    FileName = file.FileName,
                    ContentType = file.ContentType,
                    ImageData = memoryStream.ToArray(),
                    HouseId = houseId
                };

                appDbContext.Images.Add(image);
                await appDbContext.SaveChangesAsync();

                return Ok($"Image {file.FileName} uploaded successfully.");
            }
        }

        [HttpGet("{houseId}")]
        public async Task<IActionResult> GetImagesByHouseId(int houseId)
        {
            var images = await appDbContext.Images
                .Where(img => img.HouseId == houseId)
                .ToListAsync();

            if (images == null || images.Count == 0)
                return NotFound($"No images found for HouseId: {houseId}");

            return Ok(images);
        }
    }
}

