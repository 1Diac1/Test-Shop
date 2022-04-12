using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Application.Features.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using System;
using Test_Shop.Application.Features.Commands.Product;

namespace Test_Shop.Application.Features.Handlers.Product
{
    public class DeleteProductByIdCommandHandler 
        : IRequestHandler<DeleteProductByIdCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;

        public DeleteProductByIdCommandHandler(
            ILogger<DeleteProductByIdCommand> logger, 
            IApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);

            _applicationDbContext.Products.Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Delete Entity: Product had been successfully deleted ({DateTime.Now:G}).");

            return Unit.Value;
        }
    }
}
