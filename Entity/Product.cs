using EFCoreCodeFirst.PostgreSQL.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirst.PostgreSQL.Entity
{
    [Table("Products")]
    public class Product : BaseEntity
    {

        public string? ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; } = decimal.Zero;


    }
}
