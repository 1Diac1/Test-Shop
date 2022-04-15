using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.Application.Features.Queries.Product;
using Test_Shop.Application.Features.DTOs;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AutoMapper;
using MediatR;

namespace Test_Shop.Application.Features.Handlers.Product
{
    public class GetAllProductsQueryHandler 
        : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(
            IApplicationDbContext applicationDbContext, 
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Products
                .OrderBy(x => x.Name)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
