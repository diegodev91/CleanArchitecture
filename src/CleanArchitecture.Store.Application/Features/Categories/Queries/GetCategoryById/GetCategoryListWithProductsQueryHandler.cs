using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Infrastructure;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryListWithProductsQueryHandler : IRequestHandler<GetCategoryListWithProductsQuery, List<CategoryProductListVm>>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICacheService cacheService;

        public GetCategoryListWithProductsQueryHandler(IMapper mapper,
                                                        ICategoryRepository categoryRepository,
                                                        ICacheService cacheService)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.cacheService = cacheService;
        }

        public async Task<List<CategoryProductListVm>> Handle(GetCategoryListWithProductsQuery request, CancellationToken cancellationToken)
        {
            var list = await this.categoryRepository.GetCategoryByIdWithProducts(request.Id);
            var cacheData = await this.cacheService.GetCategoryCacheInformation();

            var result = this.mapper.Map<List<CategoryProductListVm>>(list);
            foreach (var item in result)
            {
                item.Provider = cacheData.Find(x => x.CategoryId == item.Id).Provider;
                item.EndOfContract = cacheData.Find(x => x.CategoryId == item.Id).EndOfContract.ToLongDateString();
            }

            return result;
        }
    }
}