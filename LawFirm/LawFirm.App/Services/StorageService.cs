using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class StorageService : BaseDataService, IStorageService
{
    public StorageService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {

    }

    public async Task DownloadFile(string file)
    {
        await _client.DownloadfileAsync(file);
    }

    public async Task<List<string>> GetFiles(string folderName)
    {
        return (await _client.ListfilesAsync(folderName)).ToList();
    }

    public async Task UploadFile(FileParameter content)
    {
        await _client.UploadfileAsync(content);
    }
}