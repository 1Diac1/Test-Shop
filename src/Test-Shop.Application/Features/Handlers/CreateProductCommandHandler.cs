using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Interfaces.DataAccess;

namespace Test_Shop.Application.Features.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ILogger _logger;

        public CreateProductCommandHandler(
            IApplicationDbContext applicationDbContext,
            ILogger<CreateProductCommandHandler> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _applicationDbContext.Products.AddAsync(entity, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation($"Create Entity: Product had been successfully created ({DateTime.Now:G}).");

            return entity.Id;
        }
    }
}
