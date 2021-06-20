using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Models.Cache;

namespace CleanArchitecture.Store.Application.Contracts.Infrastructure
{
    public interface ICacheService
    {
        Task<List<CategoryCacheInfo>> GetCategoryCacheInformation();
    }
}