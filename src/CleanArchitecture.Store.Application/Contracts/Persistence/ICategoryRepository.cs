using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Models.Category;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<CategoryBaseInfo>> GetCategoryByIdWithProducts(int Id);
    }
}