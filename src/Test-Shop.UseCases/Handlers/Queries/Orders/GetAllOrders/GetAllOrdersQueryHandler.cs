using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Test_Shop.DomainServices.Interfaces;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.UseCases.Handlers.Dto;

namespace Test_Shop.UseCases.Handlers.Queries.Orders.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ICollection<OrderDto>>
    {
        private readonly IOrderDomainService _orderService;
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAllOrdersQueryHandler(
            IOrderDomainService orderService,
            IDbContext context,
            IMapper mapper,
            ILogger<GetAllOrdersQueryHandler> logger)
        {
            _orderService = orderService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ICollection<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return orders;
        }
    }
}
