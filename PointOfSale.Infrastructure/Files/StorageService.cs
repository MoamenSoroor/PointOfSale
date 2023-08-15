using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PointOfSale.Application.Contracts.Infrastructure.Files;
using PointOfSale.Application.Models.Files;
using PointOfSale.Domain.Files;

namespace PointOfSale.Infrastructure.Files
{
    public class StorageService
    {
        private readonly ILogger<StorageService> logger;
        private readonly StoragesSettings storageSettings;
        private readonly StorageClientSettings clientSettings;
        private readonly IServiceProvider provider;
        private IStorageClient client;
        private string baseStoragePath;
        public StorageService(ILogger<StorageService> logger, StoragesSettings storageSettings, IServiceProvider provider)
        {
            this.logger = logger;
            this.storageSettings = storageSettings;
            this.provider = provider;

            var currentStorageSettings = this.storageSettings.ClientsSettings.FirstOrDefault(s => s.IsActive
            && s.FileStoragePriority == FileStoragePriority.Primary);

            baseStoragePath = currentStorageSettings.FileStorageRootPaths.First().RootPath;

            switch (currentStorageSettings.FileStorageType)
            {
                case FileStorageType.LocalServer:
                    client = provider.GetService<ILocalStorageClient>();

                    break;
                case FileStorageType.FTPServer:
                    client = provider.GetService<IRemoteStorageClient>();
                    break;
                case FileStorageType.AmazonS3:
                    throw new NotSupportedException();
                //break;
                default:
                    throw new NotSupportedException();
                    //break;

            }
        }
        public async Task<ApplicationFile> CreateFileAsync(IFormFile file)
        {
            try
            {
                var ext = Path.GetExtension(file.FileName);
                var fileName = Path.Combine(DateTime.Now.ToString("yyyy-MM-dd"),$"{Guid.NewGuid()}{ext}");//1234123412341234.txt
                var contentType = file.ContentType;
                using Stream stream = file.OpenReadStream();
                string fullPath = Path.Combine(Path.GetDirectoryName(baseStoragePath), fileName);
                await client.UploadFileAsync(stream, fullPath);


                var appFile = new ApplicationFile()
                {
                    FilePath = fileName,
                    ContentType = contentType,
                    Extension = ext,
                    FileSize = stream.Length,
                    DisplayName = file.FileName,
                    //AppFileStorageInfo = JsonConvert.SerializeObject(this.clientSettings),
                };

                return appFile;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
                throw;
            }
        }

        public async Task<List<ApplicationFile>> CreateFilesAsync(IFormCollection files)
        {
            List < ApplicationFile > appFiles = new List < ApplicationFile >();
            foreach (var item in files.Files)
            {
                var appFile = await CreateFileAsync(item);
                appFiles.Add(appFile);

            }
            return appFiles;
        }

        public async Task DeleteFileAsync(ApplicationFile appFile)
        {
            //StorageClientSettings fileStorageSettings = JsonConvert.DeserializeObject<StorageClientSettings>(appFile.AppFileStorageInfo);

            
             await client.DeleteFileAsync(appFile.FilePath);
        }        

    }
    
}
