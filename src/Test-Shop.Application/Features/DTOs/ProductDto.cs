using System.ComponentModel.DataAnnotations.Schema;
using Test_Shop.Application.Common.Mappings;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.DTOs
{
    public class ProductDto : IMapFrom<Product>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
