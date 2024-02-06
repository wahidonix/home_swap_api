using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using home_swap_api.Helpers;
using System.Threading.Tasks;

namespace home_swap_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CloudinaryController : ControllerBase
    {
        private readonly CloudinaryService cloudinary;

        public CloudinaryController(CloudinaryService cloudinary)
        {
            this.cloudinary = cloudinary;
        }

        [HttpPost("upload/{id}")]
        public async Task<IActionResult> Upload(int houseId, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }
            try
            {
                string imageUrl = await cloudinary.UploadImageAsync(houseId, file);
                return Ok(imageUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
