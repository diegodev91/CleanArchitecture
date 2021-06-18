using System.Collections.Generic;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryListWithProductsQuery : IRequest<List<CategoryProductListVm>>
    {
        public int Id { get; set; }
    }
}