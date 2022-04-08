using System.ComponentModel.DataAnnotations.Schema;
using MediatR;
using System;

namespace Test_Shop.Application.Features.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
