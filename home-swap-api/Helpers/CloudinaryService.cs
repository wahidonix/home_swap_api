using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using home_swap_api.Data;
using home_swap_api.Models;

namespace home_swap_api.Helpers

{
	public class CloudinaryService
	{
		private readonly Cloudinary cloudinary;
        private AppDbContext appDbContext;
		public CloudinaryService(AppDbContext appDbContext)
		{
            Account account = new Account(
            "df62yet39",
            "143439982291579",
            "jVYjtsT8TMJx13sGepKIbWFwPec"
            );
            cloudinary = new Cloudinary(account);
            this.appDbContext = appDbContext;
        }

        public async Task<string> UploadImageAsync(int houseId, IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                SaveToDatabase(uploadResult.SecureUri.AbsoluteUri, houseId);
                _ = cloudinary.Upload(uploadParams);

                // Return the URL of the uploaded image
                return uploadResult.SecureUri.AbsoluteUri;
            }
        }

        private void SaveToDatabase(string imageUrl, int houseId)
        {
            // Here you would save the imageUrl and houseId to your database
            // For simplicity, let's assume you're using Entity Framework Core
        
            
                appDbContext.CloudinaryImages.Add(new CloudinaryImage
                {
                    Url = imageUrl,
                    HouseId = houseId
                });
                appDbContext.SaveChanges();
            
        }


    }
}

