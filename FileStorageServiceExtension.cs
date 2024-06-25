using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAdapter.Adapter
{
    public static class FileStorageServiceExtension
    {
        public static IServiceCollection AddFileStorage(this IServiceCollection services, string? defaultDirectory)
        {
            return services.AddSingleton<IFileStorageService>(p =>
            {
                var fileStorageService = new FileStorageService();

                fileStorageService.DefaultDirectory = defaultDirectory;

                return fileStorageService;
            });
        }
    }
}
