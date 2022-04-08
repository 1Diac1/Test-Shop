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
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;

        public UpdateProductCommandHandler(
            IApplicationDbContext applicationDbContext,
            ILogger<UpdateProductCommandHandler> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (entity is null)
                throw new NotFoundException(nameof(Product), request.Id);

            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.Name = request.Name;
            entity.Modified = DateTime.Now.ToString("G");

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Update Entity: Product had been successfully updated ({DateTime.Now:G}).");

            return Unit.Value;
        }
    }
}
