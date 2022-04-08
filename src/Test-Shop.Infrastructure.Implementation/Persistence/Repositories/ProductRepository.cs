using Test_Shop.Infrastructure.Interfaces.Repositories;
using Test_Shop.Infrastructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Shop.Domain.Entities;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Test_Shop.Infrastructure.Implementation.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductRepository(IApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _applicationDbContext.Products.ToListAsync();

            return products;
        }

        public async Task<bool> IsUniqueNameAsync(string name)
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Name == name);

            return product is null;
        }

        public virtual async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<Result> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            if (product is null)
                return Result.Failure("Product is null.");

            await _applicationDbContext.Products.AddAsync(product, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            if (product is null)
                return Result.Failure("Product not found.");

            _applicationDbContext.Products.Update(product);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await this.GetByIdAsync(id);

            if (product is null)
                return Result.Failure("Product with this id not found.");

            _applicationDbContext.Products.Remove(product);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
