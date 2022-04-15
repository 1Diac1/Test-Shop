using Test_Shop.Application.Features.DTOs;
using MediatR;
using System;

namespace Test_Shop.Application.Features.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductDto> 
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
