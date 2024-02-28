using EFCoreCodeFirst.PostgreSQL.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.PostgreSQL.Entity
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public UserDetail? UserDetail { get; set; }
        public virtual ICollection<UserOrder>? UserOrders { get; set; }
    }
}
