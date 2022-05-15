using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebGym.Handlers.Interfaces;

namespace WebGym.Handlers
{
    public class ImageHandler : IImageUploadHandler
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageHandler(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadImageAndReturnItsName(IFormFile imageFile)
        {
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var imageName = Path.GetFileNameWithoutExtension(imageFile.FileName);
            var imageExt = Path.GetExtension(imageFile.FileName);
            imageName = imageName + "_" + Guid.NewGuid().ToString() + imageExt;
            var imagePath = Path.Combine(wwwRootPath + "/images/profileImages", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}
