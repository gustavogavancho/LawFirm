using Azure.Storage.Blobs;
using LawFirm.Application.Contracts.Infrastructure;
using LawFirm.Application.Models.Storage;
using Microsoft.Extensions.Options;

namespace LawFirm.Infrastructure.Storage;

public class BlobStorageService : IStorageService
{
    private readonly BlobStorageSettings _settings;

    public BlobStorageService(IOptions<BlobStorageSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName)
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(fileStream, true);
        return blobClient.Uri.ToString();
    }

    public async Task<IEnumerable<string>> ListFilesAsync()
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);
        var files = new List<string>();

        await foreach (var blobItem in blobContainerClient.GetBlobsAsync())
        {
            files.Add(blobItem.Name);
        }

        return files;
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        if (await blobClient.ExistsAsync())
        {
            var downloadInfo = await blobClient.DownloadAsync();
            return downloadInfo.Value.Content;
        }

        return null; // O maneja este caso como prefieras (p.ej., lanzando una excepción)
    }

    public async Task<bool> DeleteFileAsync(string fileName)
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);
        var blobClient = blobContainerClient.GetBlobClient(fileName);

        return await blobClient.DeleteIfExistsAsync();
    }
}