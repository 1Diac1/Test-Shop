using System.Collections.Generic;
using Test_Shop.Shared.Models;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Test_Shop.Infrastructure.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Result> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<Result> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
