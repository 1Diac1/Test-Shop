using System;
using MediatR;
using Test_Shop.Application.Features.DTOs;

namespace Test_Shop.Application.Features.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto> 
    {
        public Guid Id { get; set; }
    }
}
