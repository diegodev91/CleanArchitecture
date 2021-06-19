using System.Collections.Generic;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductListVm>>
    {

    }
}