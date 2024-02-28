using EFCoreCodeFirst.PostgreSQL.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.PostgreSQL.Entity
{
    [Table("UserOrderProducts")]
    public class UserOrderProduct : BaseEntity
    {
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public string? UserOrderId { get; set; }
        public UserOrder? UserOrder { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal CurrentPrice { get; set; } = decimal.Zero;
        public string? Note { get; set; }
        public decimal? Discount { get; set; }

    }
}
