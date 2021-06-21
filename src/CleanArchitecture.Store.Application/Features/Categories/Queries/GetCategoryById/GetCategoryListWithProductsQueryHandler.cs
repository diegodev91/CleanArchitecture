using System.Collections.Generic;
using System.Linq;
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
        private readonly IExternalProductService externalProductService;

        public GetCategoryListWithProductsQueryHandler(IMapper mapper,
                                                        ICategoryRepository categoryRepository,
                                                        ICacheService cacheService,
                                                        IExternalProductService externalProductService)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
            this.cacheService = cacheService;
            this.externalProductService = externalProductService;
        }

        public async Task<List<CategoryProductListVm>> Handle(GetCategoryListWithProductsQuery request, CancellationToken cancellationToken)
        {
            var list = await this.categoryRepository.GetCategoryByIdWithProducts(request.Id);
            var cacheData = await this.cacheService.GetCategoryCacheInformation();
            var externalData = await this.externalProductService.GetExternalProductInformation();

            var result = this.mapper.Map<List<CategoryProductListVm>>(list);
            foreach (var item in result)
            {
                item.Provider = cacheData.Find(x => x.CategoryId == item.Id).Provider;
                item.EndOfContract = cacheData.Find(x => x.CategoryId == item.Id).EndOfContract.ToLongDateString();

                foreach (var product in item.Products)
                {
                    product.InternationalCurrency = externalData.Where(x => x.Id == product.Id).FirstOrDefault().InternationalCurrency;
                    product.InternationalName = externalData.Where(x => x.Id == product.Id).FirstOrDefault().InternationalName;
                    product.InternationalPrice = externalData.Where(x => x.Id == product.Id).FirstOrDefault().InternationalPrice;
                    product.InternationalUrl = externalData.Where(x => x.Id == product.Id).FirstOrDefault().InternationalUrl;
                }
            }

            return result;
        }
    }
}