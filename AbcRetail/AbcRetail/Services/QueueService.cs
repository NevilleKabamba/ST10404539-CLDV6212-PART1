using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AbcRetail.Services
{
    public class QueueService
    {
        private readonly QueueServiceClient _queueServiceClient;

        // Constructor to initialize the QueueServiceClient using the connection string from configuration
        public QueueService(IConfiguration configuration)
        {
            _queueServiceClient = new QueueServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to send a message to the specified Azure Queue
        public async Task SendMessageAsync(string queueName, string message)
        {
            var queueClient = _queueServiceClient.GetQueueClient(queueName);
            await queueClient.CreateIfNotExistsAsync(); // Ensures the queue exists
            await queueClient.SendMessageAsync(message); // Sends the message to the queue
        }
    }
}
