using System;
using MediatR;
using Test_Shop.Application.Common.Models;

namespace Test_Shop.Application.Features.Commands
{
    public class UpdateProductCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
