using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Interfaces.Mappings;

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
