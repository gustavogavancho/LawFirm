using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IStorageService
{
    Task UploadFileAsync(FileParameter content);
}