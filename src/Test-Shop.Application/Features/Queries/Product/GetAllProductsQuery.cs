using Test_Shop.Application.Features.DTOs;
using System.Collections.Generic;
using MediatR;

namespace Test_Shop.Application.Features.Queries.Product
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}
