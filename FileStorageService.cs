using FileStorageAdapter.Adapter.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAdapter.Adapter
{
    public class FileStorageService : IFileStorageService
    {
        public string? DefaultDirectory { get; set; }

        public void DeleteFile(string fileName, string? directory = null)
        {
            if (directory is null && DefaultDirectory is null)
            {
                throw new FilesDirectoryNotSpecified(nameof(directory));
            }

            var projectDirectory = Directory.GetCurrentDirectory()
                ?? throw new UnableToLocateProject(nameof(Directory.GetCurrentDirectory));

            var fullFilePath = Path.Combine(projectDirectory, directory ?? DefaultDirectory, fileName);

            File.Delete(fullFilePath);
        }

        public async Task<string> UploadFileAsync(IFormFile file, string? directory = null)
        {
            if (directory is null && DefaultDirectory is null)
            {
                throw new FilesDirectoryNotSpecified(nameof(directory));
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var projectDirectory = Directory.GetCurrentDirectory()
                ?? throw new UnableToLocateProject(nameof(Directory.GetCurrentDirectory));

            var fullFilePath = Path.Combine(projectDirectory, directory ?? DefaultDirectory, fileName);

            var fileStream = File.Create(fullFilePath);

            await file.CopyToAsync(fileStream);

            fileStream.Close();

            return Path.Combine(fileName);
        }        
    }
}
