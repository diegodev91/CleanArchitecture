using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Infrastructure;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Application.Models.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Store.Infrastructure.Cache
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public InMemoryCacheService(IMemoryCache memoryCache,
                                    ICategoryRepository categoryRepository,
                                    IMapper mapper)
        {
            this.memoryCache = memoryCache;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<List<CategoryCacheInfo>> GetCategoryCacheInformation()
        {
            var cacheEntry = new List<CategoryCacheInfo>();
            if (!memoryCache.TryGetValue(CacheKeys.CategoryData, out cacheEntry))
            {
                var categories = await categoryRepository.ListAllAsync();
                cacheEntry = mapper.Map<List<CategoryCacheInfo>>(categories.ToList());

                memoryCache.Set(CacheKeys.CategoryData, cacheEntry);
            }

            return cacheEntry;
        }
    }
}