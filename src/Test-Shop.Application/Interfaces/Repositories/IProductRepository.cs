using System.Threading.Tasks;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsUniqueNameAsync(string name);
    }
}
