using PointOfSale.Domain.Common;
using PointOfSale.Domain.Files;

namespace PointOfSale.Application.Models.Files
{
    public class StorageClientSettings //: EntityBaseIntId
    {
        public string StorageUrl { get; set; }
        public string StorageName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public FileStorageType FileStorageType { get; set; }
        public FileStoragePriority FileStoragePriority { get; set; } = FileStoragePriority.Secondary;
        public bool IsActive { get; set; } = false;
        public string FileStorageRootPath { get; set; }

    }

}