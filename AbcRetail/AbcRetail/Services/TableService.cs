using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AbcRetail.Services
{
    public class TableService
    {
        private readonly TableServiceClient _tableServiceClient;

        // Constructor to initialize the TableServiceClient using the connection string from configuration
        public TableService(IConfiguration configuration)
        {
            _tableServiceClient = new TableServiceClient(configuration["AzureStorage:ConnectionString"]);
        }

        // Method to add a new entity to the specified Azure Table
        public async Task AddEntityAsync<T>(T entity) where T : class, ITableEntity
        {
            var tableClient = _tableServiceClient.GetTableClient("CustomerProfiles");
            await tableClient.CreateIfNotExistsAsync(); // Ensures the table exists
            await tableClient.AddEntityAsync(entity); // Adds the entity to the table
        }
    }
}
