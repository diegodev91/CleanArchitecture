using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}