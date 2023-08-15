using FluentFTP;
using FluentFTP.Exceptions;
using Microsoft.Extensions.Logging;
using PointOfSale.Application.Contracts.Infrastructure.Files;
using PointOfSale.Application.Models.Files;

namespace PointOfSale.Infrastructure.Files
{
    public class RemoteStorageClient : IRemoteStorageClient, IDisposable
    {
        // using FluentFtp;
        private  IFtpClient client;
        private  IAsyncFtpClient asyncFtpClient;
        private readonly ILogger<RemoteStorageClient> logger;
        private bool disposedValue;


        public RemoteStorageClient(IFtpClient ftpClient, IAsyncFtpClient asyncFtpClient, ILogger<RemoteStorageClient> logger)
        {
            this.client = ftpClient;
            this.asyncFtpClient = asyncFtpClient;
            this.logger = logger;
        }

        public virtual void UploadFile(Stream fileStream, string fullPath)
        {

            FtpStatus status = client.UploadStream(fileStream, fullPath, createRemoteDir: true);
            if (status == FtpStatus.Failed)
            {
                logger.LogError("failed to upload the file, ftpStatus Failed: {fullPath}",fullPath);
                throw new Exception("exception in uploading file");
            }
        }

        public virtual void UploadFile(byte[] content, string fullPath)
        {
            var status = client.UploadBytes(content, fullPath, createRemoteDir: true);

            if (status == FtpStatus.Failed)
            {
                logger.LogError("failed to upload the file, ftpStatus Failed: {fullPath}", fullPath);
                throw new Exception("exception in uploading file");
            }
        }

        public virtual async Task UploadFileAsync(Stream fileStream, string fullPath)
        {

            FtpStatus status = await asyncFtpClient.UploadStream(fileStream, fullPath, createRemoteDir: true);
            if (status == FtpStatus.Failed)
            {
                logger.LogError("failed to upload the file, ftpStatus Failed: {fullPath}", fullPath);
                throw new Exception("exception in uploading file");
            }
        }

        public virtual async Task UploadFileAsync(byte[] content, string fullPath)
        {
            var status = await asyncFtpClient.UploadBytes(content, fullPath, createRemoteDir: true);

            if (status == FtpStatus.Failed)
            {
                logger.LogError("failed to upload the file, ftpStatus Failed: {fullPath}", fullPath);
                throw new Exception("exception in uploading file");
            }
        }

        public virtual byte[] DownloadFile(string fullPath)
        {

            try
            {
                bool result = client.DownloadBytes(out byte[] content, fullPath);
                if (!result) throw new FtpException("download failed exception");
                return content;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "failed to Download the file, ftpStatus Failed: {fullPath}", fullPath);
                throw;
            }
        }

        public virtual async Task<byte[]> DownloadFileAsync(string fullPath)
        {

            try
            {
                byte[] data = await asyncFtpClient.DownloadBytes(fullPath, 0);
                return data;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "failed to Download the file, ftpStatus Failed: {fullPath}", fullPath);
                throw;
            }
        }


        public virtual Stream OpenDownloadStream(string fullPath)
        {
            return client.OpenRead(fullPath, FtpDataType.Binary);
        }

        public virtual async Task<Stream> OpenDownloadStreamAsync(string fullPath)
        {
            return await asyncFtpClient.OpenRead(fullPath, FtpDataType.Binary);
        }




        public virtual bool FileExists(string fullPath)
        {
            return client.FileExists(fullPath);
        }

        public virtual bool DirectoryExists(string fullPath)
        {
            return client.DirectoryExists(fullPath);
        }

        public Task CreateDirectoryAsync(string fullPath)
        {

            return asyncFtpClient.CreateDirectory(fullPath);
        }


        public virtual async Task<bool> FileExistsAsync(string fullPath)
        {

            return await asyncFtpClient.FileExists(fullPath);
        }

        public virtual async Task<bool> DirectoryExistsAsync(string fullPath)
        {
            return await asyncFtpClient.DirectoryExists(fullPath);
        }

        public virtual void DeleteFile(string fullPath)
        {

            client.DeleteFile(fullPath);
        }

        public virtual void DeleteDirectory(string fullPath)
        {
            client.DeleteDirectory(fullPath);
        }

        public virtual Task DeleteFileAsync(string fullPath)
        {
            return asyncFtpClient.DeleteFile(fullPath);
        }

        public virtual Task DeleteDirectoryAsync(string fullPath)
        {
            return asyncFtpClient.DeleteDirectory(fullPath,FtpListOption.AllFiles);
        }


        //MoveFileAsync
        /// <summary>
        /// Note that if the new directory is not exists exception will be thrown
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="newRelativePath"></param>
        /// <returns></returns>
        public virtual Task MoveFileAsync(string fullPath, string newRelativePath)
        {
            return asyncFtpClient.MoveFile(fullPath, newRelativePath,
                    existsMode: FtpRemoteExists.Overwrite);



        }
        public virtual bool MoveFile(string fullPath, string newRelativePath)
        {
            var result = client.MoveFile(fullPath, newRelativePath,
                existsMode: FtpRemoteExists.Overwrite);
            return result;
        }




        #region disposing
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                this.client.Disconnect();
                this.client = null;
                this.asyncFtpClient.Disconnect();
                this.asyncFtpClient = null;
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RemoteFileService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }



        #endregion
    }




}