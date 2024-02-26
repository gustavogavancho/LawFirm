﻿using Azure.Storage.Blobs;
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

    public async Task<string> UploadFileAsync(Stream fileStream, string blobName)
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);

        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);

        var blobClient = blobContainerClient.GetBlobClient(blobName);

        await blobClient.UploadAsync(fileStream, true);

        return blobClient.Uri.ToString();
    }

    public async Task<IEnumerable<string>> ListFilesAsync(string folder)
    {
        var blobServiceClient = new BlobServiceClient(_settings.ConnectionString);
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(_settings.Container);
        var files = new List<string>();

        string folderPrefix = string.IsNullOrEmpty(folder) ? "" : folder.TrimEnd('/') + '/';

        await foreach (var blobItem in blobContainerClient.GetBlobsAsync(prefix: folderPrefix))
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