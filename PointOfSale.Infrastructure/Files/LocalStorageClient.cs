using PointOfSale.Application.Contracts.Infrastructure.Files;
using PointOfSale.Application.Models.Files;

namespace PointOfSale.Infrastructure.Files
{
    public class LocalStorageClient : ILocalStorageClient
    {
        public LocalStorageClient()
        {
            
        }


        public Task CreateDirectoryAsync(string fullPath)
        {
            return Task.Run(() => Directory.CreateDirectory(fullPath));
        }


        public virtual Task DeleteDirectoryAsync(string fullPath)
        {
            return Task.Run(() =>
            {
                Directory.Delete(fullPath, true);
            });
        }


        public virtual Task DeleteFileAsync(string fullPath)
        {
            return Task.Run(() => {
                File.Delete(fullPath);
            });
        }

        public virtual Task<bool> DirectoryExistsAsync(string fullPath)
        {
            return Task.Run(() => {
                return Directory.Exists(fullPath);
            });
        }


        public virtual Task<byte[]> DownloadFileAsync(string fullPath)
        {
            return File.ReadAllBytesAsync(fullPath);
        }

        public virtual Task<bool> FileExistsAsync(string fullPath)
        {
            return Task.Run(() =>
            {
                return File.Exists(fullPath);

            });
        }

        public Task MoveFileAsync(string fullPath, string newFullPath)
        {

            return Task.Run(() =>
            {
                FileInfo file = new FileInfo(newFullPath);
                if (!file.Directory.Exists) file.Directory.Create();
                File.Copy(fullPath, newFullPath, true);
            });
        }

        public virtual Stream OpenDownloadStream(string fullPath)
        {
            return new BufferedStream(File.OpenRead(fullPath));

        }

        public virtual Task<Stream> OpenDownloadStreamAsync(string fullPath)
        {

            return Task.Run<Stream>(() =>
            {
                return new BufferedStream(File.OpenRead(fullPath));
            });
        }

        public virtual void UploadFile(byte[] content, string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);
            if (!file.Directory.Exists) file.Directory.Create();

            File.WriteAllBytes(fullPath, content);
        }

        public virtual void UploadFile(Stream fileStream, string fullPath)
        {
            FileInfo file = new FileInfo(fullPath);
            if (!file.Directory.Exists) file.Directory.Create();

            using BufferedStream stream = new BufferedStream(File.OpenWrite(fullPath));
            fileStream.CopyTo(stream);
        }

        public virtual async Task UploadFileAsync(byte[] content, string fullPath)
        {

            FileInfo file = new FileInfo(fullPath);
            if (!file.Directory.Exists) file.Directory.Create();

            await File.WriteAllBytesAsync(fullPath, content);
        }

        public virtual async Task UploadFileAsync(Stream fileStream, string fullPath)
        {

            FileInfo file = new FileInfo(fullPath);
            if (!file.Directory.Exists) file.Directory.Create();

            using BufferedStream stream = new BufferedStream(File.OpenWrite(fullPath));
            await fileStream.CopyToAsync(stream);
        }

    }



}