using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Store.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoryByIdWithProducts(int id)
        {
            var categories = await this._dbContext.Categories
                                    .Where(x => x.Id == id)
                                    .Include(x => x.Products).ToListAsync();
            return categories;
        }
    }
}