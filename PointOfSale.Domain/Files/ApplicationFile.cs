using PointOfSale.Domain.Common;

namespace PointOfSale.Domain.Files
{
    public class ApplicationFile : AuditableEntity
    {
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }

        public string DisplayName { get; set; }
        public int UseCount { get; set; }
        public bool IsDeleted { get; set; }

        public AppFileStorageInfo AppFileStorageInfo { get; set; }

    }



}