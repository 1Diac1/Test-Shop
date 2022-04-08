using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Test_Shop.Application.Common.Exceptions;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

namespace Test_Shop.Application.Features.Handlers
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
                throw new NotFoundException(nameof(Product), request.Id);

            _applicationDbContext.Products.Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Delete Entity: Product had been successfully deleted ({DateTime.Now:G}).");

            return Unit.Value;
        }
    }
}
