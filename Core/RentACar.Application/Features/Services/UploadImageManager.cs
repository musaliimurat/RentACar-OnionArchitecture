using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RentACar.Application.Interfaces.Services;




namespace RentACar.Application.Features.Services
{
    public class UploadImageManager : IUploadImageService
    {


        public async Task<List<string>> UploadImagesAsync(IFormFileCollection files, string relativeTargetFolder, IWebHostEnvironment env)
        {
            var uploadedFilePaths = new List<string>();

            var fullTargetPath = Path.Combine(env.WebRootPath, relativeTargetFolder);

            if (!Directory.Exists(fullTargetPath))
                Directory.CreateDirectory(fullTargetPath);

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var fullPath = Path.Combine(fullTargetPath, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var dbPath = Path.Combine(relativeTargetFolder, fileName).Replace("\\", "/");

                    uploadedFilePaths.Add(dbPath);
                }
            }

            return uploadedFilePaths;
        }
    }
}
