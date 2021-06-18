using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoryByIdWithProducts(int Id);
    }
}