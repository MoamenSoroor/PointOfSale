//using Microsoft.Extensions.DependencyInjection;
//using PointOfSale.Application.Contracts.Infrastructure.Files;
//using PointOfSale.Application.Models.Files;
//using PointOfSale.Domain.Files;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PointOfSale.Infrastructure.Files
//{
//    public class StorageClientBase : IStorageClient
//    {



//        private readonly StoragesSettings storageSettings;
//        private readonly IServiceProvider provider;
//        private IStorageClient client;
//        public StorageClientBase(StoragesSettings storageSettings,IServiceProvider provider)
//        {
//            this.storageSettings = storageSettings;
//            this.provider = provider;

//            var currentStorageSettings = this.storageSettings.ClientsSettings.FirstOrDefault(s => s.IsActive
//            && s.FileStoragePriority == FileStoragePriority.Primary);

//            switch (currentStorageSettings.FileStorageType)
//            {
//                case FileStorageType.LocalServer:
//                    client = provider.GetService<ILocalStorageClient>();

//                    break;
//                case FileStorageType.FTPServer:
//                    client = provider.GetService<IRemoteStorageClient>();
//                    break;
//                case FileStorageType.AmazonS3:
//                    throw new NotSupportedException();
//                    //break;
//                default:
//                    throw new NotSupportedException();
//                    //break;
//            }
//        }


//        public Task CreateDirectoryAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteDirectoryAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteFileAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> DirectoryExistsAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<byte[]> DownloadFileAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> FileExistsAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task MoveFileAsync(string fullPath, string newFullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Stream> OpenDownloadStreamAsync(string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UploadFileAsync(byte[] content, string fullPath)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UploadFileAsync(Stream fileStream, string fullPath)
//        {
//            throw new NotImplementedException();
//        }
//    }
    
//}
