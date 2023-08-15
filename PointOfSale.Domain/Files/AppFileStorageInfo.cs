namespace PointOfSale.Domain.Files
{
    public class AppFileStorageInfo
    {
        public string StorageName { get; set; }
        public FileStorageType FileStorageType { get; set; }
        public bool IsActive { get; set; } = false;
        public string FileStorageRootPath { get; set; }
    }


}