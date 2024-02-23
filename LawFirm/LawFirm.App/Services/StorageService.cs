using Blazored.LocalStorage;
using LawFirm.App.Contracts;
using LawFirm.App.Services.Base;

namespace LawFirm.App.Services;

public class StorageService : BaseDataService,  IStorageService
{
    public StorageService(IClient client, ILocalStorageService localStorage) : base(client, localStorage)
    {

    }

    public async Task UploadFileAsync(FileParameter content)
    {
        await _client.UploadAsync(content);
    }
}