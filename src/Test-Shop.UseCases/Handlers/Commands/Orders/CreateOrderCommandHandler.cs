using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Test_Shop.Entities.Models;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

namespace Test_Shop.UseCases.Handlers.Commands.Orders
{
    public class CreateOrderCommandHandler : AsyncRequestHandler<CreateOrderCommand>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateOrderCommandHandler(
            IDbContext context, 
            IMapper mapper, 
            ILogger<CreateOrderCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        protected override async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: проверить на счет OrderItems
            var order = _mapper.Map<Order>(request.Dto);
            order.CreationDate = DateTime.Now;

            await _context.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
