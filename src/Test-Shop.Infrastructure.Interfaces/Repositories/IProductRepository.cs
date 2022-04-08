using System.Threading;
using System.Threading.Tasks;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Infrastructure.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsUniqueNameAsync(string name);
    }
}
