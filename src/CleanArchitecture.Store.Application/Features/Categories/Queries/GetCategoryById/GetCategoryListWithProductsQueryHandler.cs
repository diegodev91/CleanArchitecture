using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryListWithProductsQueryHandler : IRequestHandler<GetCategoryListWithProductsQuery, List<CategoryProductListVm>>
    {
        private readonly IMapper mapper;
        private readonly ICategoryRepository categoryRepository;

        public GetCategoryListWithProductsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryProductListVm>> Handle(GetCategoryListWithProductsQuery request, CancellationToken cancellationToken)
        {
            var list = await this.categoryRepository.GetCategoryByIdWithProducts(request.Id);
            return this.mapper.Map<List<CategoryProductListVm>>(list);
        }
    }
}