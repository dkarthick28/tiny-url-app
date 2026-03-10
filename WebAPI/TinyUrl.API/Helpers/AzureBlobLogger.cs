using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System.Text;

namespace TinyUrl.API.Helpers
{
    public class AzureBlobLogger
    {
       private readonly BlobContainerClient _containerClient;

        public AzureBlobLogger(IConfiguration configuration)
        {
            var connectionString = configuration["BlobStorage:ConnectionString"];
            var containerName = configuration["BlobStorage:ContainerName"];

            var blobServiceClient = new BlobServiceClient(connectionString);

            _containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            _containerClient.CreateIfNotExists();
        }

        public async Task LogAsync(string message)
        {
            var now = DateTime.UtcNow;

            var blobName = $"{now:yyyy}/{now:MM}/{now:dd}.txt";

            var appendBlobClient = _containerClient.GetAppendBlobClient(blobName);

            if (!await appendBlobClient.ExistsAsync())
            {
                await appendBlobClient.CreateAsync();
            }

            var logMessage = $@"
-----------------------------
Time: {now}
Message: {message}
-----------------------------";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(logMessage));

            await appendBlobClient.AppendBlockAsync(stream);
        }
    }

}
