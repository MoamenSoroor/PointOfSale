using PointOfSale.Domain.Files;
using System.Net;

namespace PointOfSale.Application.Models.Files
{
    public class StoragesSettings
    {

        public static StoragesSettings GetInstance()
        {
            return new StoragesSettings()
            {
                ClientsSettings = new List<StorageClientSettings>()
                {
                    new StorageClientSettings()
                    {
                        StorageUrl = Dns.GetHostName(),
                        StorageName = "pos-system-ftp-server",
                        UserName = "FtpServer",
                        Password = "123456",
                        ApiKey = "",
                        FileStorageType = FileStorageType.FTPServer,
                        FileStoragePriority = FileStoragePriority.Primary,
                        IsActive = true,
                        FileStorageRootPath="app/pos"
                    }
                    ,
                     new StorageClientSettings()
                    {
                        StorageUrl = Dns.GetHostName(),
                        StorageName = "pos-system-app-server",
                        UserName = "",
                        Password = "",
                        ApiKey = "",
                        FileStorageType = FileStorageType.LocalServer,
                        FileStoragePriority = FileStoragePriority.Secondary,
                        IsActive = true,
                        FileStorageRootPath="app/pos"
                    }
                }
            };
        }

        public List<StorageClientSettings> ClientsSettings { get; set; }

    }

}