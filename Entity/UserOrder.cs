using EFCoreCodeFirst.PostgreSQL.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.PostgreSQL.Entity
{
    [Table("UserOrders")]
    public class UserOrder : BaseEntity
    {
        public string Status { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; } = decimal.Zero;
        [Required]
        public string? UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<UserOrderProduct>? UserOrderProducts { get; set; }


    }
}
