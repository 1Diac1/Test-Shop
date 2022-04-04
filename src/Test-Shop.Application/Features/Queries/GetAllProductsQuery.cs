using MediatR;
using System.Collections.Generic;
using Test_Shop.Application.Features.DTOs;

namespace Test_Shop.Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}
