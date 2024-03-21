namespace LawFirm.Application.Contracts.Infrastructure;

public interface IStorageService
{
    Task<string> UploadFile(Stream fileStream, string blobName);
    Task<IEnumerable<string>> ListFiles(string folder);
    Task<Stream> DownloadFile(string fileName);
    Task<bool> DeleteFile(string fileName);
}