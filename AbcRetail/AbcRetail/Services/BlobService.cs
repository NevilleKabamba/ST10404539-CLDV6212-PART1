using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace AbcRetail.Services
{
    public class BlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        // Constructor to initialize the BlobServiceClient using the connection string from configuration
        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to upload a blob (file) to the specified container in Azure Blob Storage
        public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync(); // Ensures the container exists
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(content, true); // Uploads the content to the blob
        }
    }
}
