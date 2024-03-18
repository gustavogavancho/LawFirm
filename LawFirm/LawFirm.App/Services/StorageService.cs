using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class StorageService : BaseDataService, IStorageService
{
    public StorageService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {

    }

    public async Task DeleteFile(string file)
    {
        await _client.DeleteFileAsync(file);
    }
    public async Task<byte[]> DownloadFile(string file)
    {
        var stream = await _client.DownloadFileAsync(file);

        return await ReadStreamAsync(stream.Stream);
    }

    public async Task<List<string>> GetFiles(string folderName)
    {
        return (await _client.ListFilesAsync(folderName)).ToList();
    }

    public async Task UploadFile(FileParameter content)
    {
        await _client.UploadFileAsync(content);
    }

    private static async Task<byte[]> ReadStreamAsync(Stream stream)
    {
        // Create a MemoryStream to hold the read data
        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Copy the stream to the MemoryStream
            await stream.CopyToAsync(memoryStream);

            // Return the byte array
            return memoryStream.ToArray();
        }
    }
}