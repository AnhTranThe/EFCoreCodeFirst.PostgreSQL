using EFCoreCodeFirst.PostgreSQL.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.PostgreSQL.Entity
{
    [Table("UserDetails")]
    public class UserDetail : BaseEntity
    {

        public string Avatar { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public DateTimeOffset Birthday { get; set; }
        [Required]
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
