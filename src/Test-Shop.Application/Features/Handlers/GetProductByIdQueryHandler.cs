using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Application.Features.DTOs;
using Test_Shop.Application.Features.Queries;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

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
            var entity = await _applicationDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Product), cancellationToken);

            var mappedEntity = _mapper.Map<Product, ProductDto>(entity);

            return mappedEntity;
        }
    }
}
