using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, List<CategoryListVm>>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await this.categoryRepository.ListAllAsync()).OrderBy(x => x.Name);
            return this.mapper.Map<List<CategoryListVm>>(allCategories);
        }

    }
}