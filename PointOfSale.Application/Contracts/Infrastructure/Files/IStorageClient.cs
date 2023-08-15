using PointOfSale.Application.Models.Files;

namespace PointOfSale.Application.Contracts.Infrastructure.Files
{
    public interface IStorageClient
    {
        //public FileStorageType FileStorageType { get; }
        Task DeleteDirectoryAsync(string fullPath);
        Task DeleteFileAsync(string fullPath);
        Task<bool> DirectoryExistsAsync(string fullPath);
        Task<byte[]> DownloadFileAsync(string fullPath);
        Task<bool> FileExistsAsync(string fullPath);
        Task MoveFileAsync(string fullPath, string newFullPath);
        Task<Stream> OpenDownloadStreamAsync(string fullPath);
        Task UploadFileAsync(byte[] content, string fullPath);
        Task UploadFileAsync(Stream fileStream, string fullPath);
        Task CreateDirectoryAsync(string fullPath);

    }




}