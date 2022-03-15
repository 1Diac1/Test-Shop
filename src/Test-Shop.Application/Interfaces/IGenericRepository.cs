using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test_Shop.Application.Common.Models;

namespace Test_Shop.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<DataResponse<T>> GetByIdAsync(Guid id);
        Task<DataResponse<IEnumerable<T>>> GetAllAsync();
        Task<BaseResponse> UpdateAsync(T entity);
        Task<BaseResponse> CreateAsync(T entity);
        Task<BaseResponse> DeleteAsync(Guid id);
    }
}
