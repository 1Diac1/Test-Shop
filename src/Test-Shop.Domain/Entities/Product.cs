using System.ComponentModel.DataAnnotations.Schema;
using Test_Shop.Domain.Common;

namespace Test_Shop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
