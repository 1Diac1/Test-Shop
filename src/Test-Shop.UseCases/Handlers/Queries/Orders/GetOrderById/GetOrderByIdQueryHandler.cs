using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Test_Shop.DomainServices.Interfaces;
using Test_Shop.Entities.Exceptions;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.UseCases.Handlers.Dto;

namespace Test_Shop.UseCases.Handlers.Queries.Orders.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
    {
        private readonly IOrderDomainService _orderService;
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetOrderByIdQueryHandler(
            IOrderDomainService orderService,
            IDbContext context, 
            IMapper mapper, 
            ILogger<GetOrderByIdQueryHandler> logger)
        {
            _orderService = orderService;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.AsNoTracking()
                .Include(o => o.OrderItems).ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (order is null) throw new EntityNotFoundException();

            var result = _mapper.Map<OrderDto>(order);
            result.TotalPrice = _orderService.GetTotalPrice(order);

            return result;
        }
    }
}
