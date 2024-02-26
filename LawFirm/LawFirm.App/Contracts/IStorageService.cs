using LawFirm.App.Services.Base;

namespace LawFirm.App.Contracts;

public interface IStorageService
{
    Task UploadFile(FileParameter content);
    Task<List<string>> GetFiles(string folderName);
    Task DownloadFile(string file);
}