using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.PostgreSQL.Common
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset CreateOn { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdateOn { get; set; }
        public string CreateBy { get; set; } = string.Empty;
        public string UpdateBy { get; set; } = string.Empty;
    }
}
