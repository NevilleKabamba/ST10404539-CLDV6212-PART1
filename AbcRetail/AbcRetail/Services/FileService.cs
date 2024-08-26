using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace AbcRetail.Services
{
    public class FileService
    {
        private readonly ShareServiceClient _fileServiceClient;

        // Constructor to initialize the ShareServiceClient using the connection string from configuration
        public FileService(IConfiguration configuration)
        {
            _fileServiceClient = new ShareServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to upload a file to the specified Azure File Share
        public async Task UploadFileAsync(string shareName, string fileName, Stream content)
        {
            var shareClient = _fileServiceClient.GetShareClient(shareName);
            await shareClient.CreateIfNotExistsAsync(); // Ensures the share exists
            var directoryClient = shareClient.GetRootDirectoryClient();
            var fileClient = directoryClient.GetFileClient(fileName);
            await fileClient.CreateAsync(content.Length); // Creates the file in the share
            await fileClient.UploadRangeAsync(new HttpRange(0, content.Length), content); // Uploads the content to the file
        }
    }
}
