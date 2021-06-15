using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Product>
    {

    }
}