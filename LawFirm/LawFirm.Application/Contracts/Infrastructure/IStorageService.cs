namespace LawFirm.Application.Contracts.Infrastructure;

public interface IStorageService
{
    Task<string> UploadFileAsync(Stream fileStream, string blobName);
    Task<IEnumerable<string>> ListFilesAsync(string folder);
    Task<Stream> DownloadFileAsync(string fileName);
    Task<bool> DeleteFileAsync(string fileName);
}