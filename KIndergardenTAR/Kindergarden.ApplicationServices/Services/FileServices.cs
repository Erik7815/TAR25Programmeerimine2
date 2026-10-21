using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Kindergarden.Core.Domain;
using Kindergarden.Core.Dto;
using Kindergarden.Core.ServiceInterface;
using Kindergarden.Data;

namespace Kindergarden.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly KindergardenContext _context;
        private readonly IHostEnvironment _webHost;

        public FileServices
            (
                KindergardenContext context,
                IHostEnvironment webHost
            )
        {
            _context = context;
            _webHost = webHost;
        }
        public void FilesToApi(KindergardenDto dto, KindergardenDomain domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\");
                }
                foreach (var file in dto.Files)
                {

                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "wwwroot", "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        FileToApi path = new FileToApi
                        {
                            
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            KindergardenId = domain.Id
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var imageId = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"
                + imageId.ExistingFilePath;

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _context.FileToApis.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }
        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dto)
        {
            foreach (var image in dto)
            {
                var imageID = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.Id == image.Id);
                var filePath = _webHost.ContentRootPath + "\\wwwroot\\multipleFileUpload\\"
                               + imageID.ExistingFilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.FileToApis.Remove(imageID);
                await _context.SaveChangesAsync();

            }
            return null;
        }
    }
}
