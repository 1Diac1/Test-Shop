using MediatR;
using System.Collections.Generic;
using Test_Shop.Application.Common.Models;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Queries
{
    public class GetAllProductsQuery : IRequest<DataResponse<IEnumerable<Product>>>
    {

    }
}
