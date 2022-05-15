using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Handlers.Interfaces
{
    public interface IImageUploadHandler
    {
        public Task<string> UploadImageAndReturnItsName(IFormFile imageFile);

    }
}
