using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Application.Features.DTOs;
using Test_Shop.Application.Features.Queries;
using Test_Shop.Application.Interfaces;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Handlers
{
    public class GetProductByIdQueryHandler
        : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(
            IApplicationDbContext applicationDbContext, 
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Products.FindAsync(request.Id, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Product), cancellationToken);

            var mappedEntity = _mapper.Map<Product, ProductDto>(entity);

            return mappedEntity;
        }
    }
}
