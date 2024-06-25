using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAdapter.Adapter
{
    /// <summary>
    /// Provides tool to save and delete files on local storage.
    /// </summary>
    public interface IFileStorageService
    {
        /// <summary>
        /// Default relative path to save or delete files.
        /// </summary>
        string? DefaultDirectory { get; set; }

        /// <summary>
        /// This method deletes file by its name and its directory.
        /// </summary>
        /// <param name="fileName">Name of the file with the extension.</param>
        /// <param name="directory">The directory where the file stores.</param>
        /// <exception cref="FilesDirectoryNotSpecified">Throws when <paramref name="directory"/> and <paramref name="DefaultDirectory"/> are null.</exception>
        /// <exception cref="UnableToLocateProject">Throws when method cannot find directory of project.</exception>
        Task<string> UploadFileAsync(IFormFile file, string? directory = null);

        /// <summary>
        /// This method uploads <c>IFormFile</c> typed file to the directory asynchronously.
        /// </summary>
        /// <param name="file">File to upload.</param>
        /// <param name="directory">The directory where the file stores.</param>
        /// <returns>Relative path to the created file.</returns>
        /// <exception cref="FilesDirectoryNotSpecified">Throws when <paramref name="directory"/> and <paramref name="DefaultDirectory"/> are null.</exception>
        /// <exception cref="UnableToLocateProject">Throws when method cannot find directory of project.</exception>
        void DeleteFile(string fileName, string? directory = null);
    }
}
