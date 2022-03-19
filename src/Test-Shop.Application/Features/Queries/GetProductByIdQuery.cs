using System;
using MediatR;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Queries
{
    public class GetProductByIdQuery : IRequest<DataResponse<Product>> 
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
