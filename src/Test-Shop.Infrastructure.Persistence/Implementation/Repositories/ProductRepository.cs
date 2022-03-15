using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Domain.Entities;
using Test_Shop.Infrastructure.Persistence.Data;

namespace Test_Shop.Infrastructure.Persistence.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataResponse<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            return new DataResponse<IEnumerable<Product>>(products);
        }

        public async Task<DataResponse<Product>> GetByIdAsync(Guid id)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return product is null ? new DataResponse<Product>("Product not found.") : new DataResponse<Product>(product);
        }

        public async Task<bool> IsUniqueNameAsync(string name)
        {
            var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Name == name);

            return product is null;
        }

        public async Task<BaseResponse> CreateAsync(Product product)
        {
            if (product is null)
                return new BaseResponse("Product is null.");

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new BaseResponse(true);
        }

        public async Task<BaseResponse> UpdateAsync(Product product)
        {
            var response = await this.GetByIdAsync(product.Id);

            if (response.Success is false)
                return response;

            var updatedProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image
            };

            _context.Products.Update(updatedProduct);
            await _context.SaveChangesAsync();

            return new BaseResponse(true);
        }

        public async Task<BaseResponse> DeleteAsync(Guid id)
        {
            var response = await this.GetByIdAsync(id);

            if (response.Success is false)
                return response;

            _context.Products.Remove(response.Data);
            await _context.SaveChangesAsync();

            return new BaseResponse(true);
        }
    }
}
