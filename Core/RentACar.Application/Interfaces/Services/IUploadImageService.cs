using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IUploadImageService
    {
        Task<List<string>> UploadImagesAsync(IFormFileCollection files, string relativeTargetFolder, IWebHostEnvironment env);
    }
}
