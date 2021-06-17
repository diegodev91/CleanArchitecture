using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;

namespace CleanArchitecture.Store.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
         public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}