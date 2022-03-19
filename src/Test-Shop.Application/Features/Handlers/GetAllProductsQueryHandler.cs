using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Common.Models.Responses;
using Test_Shop.Application.Features.Queries;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Handlers
{
    // TODO: Make AutoMapper
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, DataResponse<IEnumerable<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DataResponse<IEnumerable<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var response = await _productRepository.GetAllAsync();

            return response;
        }
    }
}
