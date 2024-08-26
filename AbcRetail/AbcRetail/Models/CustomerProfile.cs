using Azure;
using Azure.Data.Tables;
using System;

namespace AbcRetail.Models
{
    public class CustomerProfile : ITableEntity
    {
        // Required properties for Azure Table Storage entities
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Custom properties for customer profiles
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor to initialize the partition and row keys
        public CustomerProfile()
        {
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString(); // Generates a unique identifier for each row
        }
    }
}
