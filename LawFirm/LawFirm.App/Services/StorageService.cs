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
    public async Task DownloadFile(string file)
    {
        //var check = await _client.DownloadFileAsync(file);

        return null;
    }

    public async Task<List<string>> GetFiles(string folderName)
    {
        return (await _client.ListFilesAsync(folderName)).ToList();
    }

    public async Task UploadFile(FileParameter content)
    {
        await _client.UploadFileAsync(content);
    }

    Task<FileResponse> IStorageService.DownloadFile(string file)
    {
        throw new NotImplementedException();
    }
}