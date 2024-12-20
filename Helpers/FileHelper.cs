using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using MusicApi.Models;

namespace MusicApi.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = "AZURE_STORAGE_CONNECTION_STRING";


            // The container name
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString(); // Replace with your actual container name

            // Initialize BlobContainerClient
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            await containerClient.CreateIfNotExistsAsync();
            // Create local directory and file
            string localPath = Path.Combine(Path.GetTempPath(), "data");
            Directory.CreateDirectory(localPath);

            string fileName = $"quickstart-{Guid.NewGuid()}.txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write content to the file
            await System.IO.File.WriteAllTextAsync(localFilePath, "Hello, World");

            // Upload the file as a blob
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(localFilePath, true);



            Console.WriteLine("Listing blobs...");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
            return blobClient.Uri.AbsoluteUri;
        }
        public static async Task<string> UploadFiles(IFormFile file)
        {
            string connectionString = "AZURE_STORAGE_CONNECTION_STRING";


            // The container name
            string containerName = "quickstartblobs" + Guid.NewGuid().ToString(); // Replace with your actual container name

            // Initialize BlobContainerClient
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
            await containerClient.CreateIfNotExistsAsync();
            // Create local directory and file
            string localPath = Path.Combine(Path.GetTempPath(), "data");
            Directory.CreateDirectory(localPath);

            string fileName = $"quickstart-{Guid.NewGuid()}.txt";
            string localFilePath = Path.Combine(localPath, fileName);

            // Write content to the file
            await System.IO.File.WriteAllTextAsync(localFilePath, "Hello, World");

            // Upload the file as a blob
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(localFilePath, true);



            Console.WriteLine("Listing blobs...");

            // List all blobs in the container
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                Console.WriteLine("\t" + blobItem.Name);
            }
            return blobClient.Uri.AbsoluteUri;
        }
    }

}

