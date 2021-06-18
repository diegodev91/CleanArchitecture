using System.Collections.Generic;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryListVm>>
    {

    }
}