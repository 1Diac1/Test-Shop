using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Common.Models.Responses;

namespace Test_Shop.Application.Features.Commands
{
    public class CreateProductCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
