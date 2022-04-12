using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Application.Features.Queries;
using Test_Shop.Application.Features.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using MediatR;

namespace Test_Shop.Application.Features.Handlers.Product
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
            var entity = await _applicationDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Domain.Entities.Product), cancellationToken);

            var mappedEntity = _mapper.Map<Domain.Entities.Product, ProductDto>(entity);

            return mappedEntity;
        }
    }
}
