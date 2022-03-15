using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Features.Queries;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Handlers
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, DataResponse<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DataResponse<Product>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _productRepository.GetByIdAsync(request.Id);

            return response;
        }
    }
}
