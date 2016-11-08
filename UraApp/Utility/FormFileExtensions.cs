 
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace UraApp.Utility
{
    public static class FormFileHelpers
    {
        private static int DefaultBufferSize = 80 * 1024;
        /// <summary>
        /// Asynchronously saves the contents of an uploaded file.
        /// </summary>
        /// <param name="formFile">The <see cref="IFormFile"/>.</param>
        /// <param name="filename">The name of the file to create.</param>
        public static string Save(
            IFormFile formFile,
           string rootpath,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            var parsedContentDisposition = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition);
            string FilePath = parsedContentDisposition.FileName.Trim('"');
            string FileExtension = Path.GetExtension(FilePath);
            var uploadDir = rootpath;
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            var imageUrl = uploadDir + FilePath; //+ FileExtension;
          //  formFile.SaveAsS(imageUrl);
            return FilePath;
        }
    }
}
