using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Store.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductListVm>>
    {
        private readonly IAsyncRepository<Product> ProductRepository;
        private readonly IMapper mapper;

        public GetProductListQueryHandler(IMapper mapper, IAsyncRepository<Product> ProductRepository)
        {
            this.mapper = mapper;
            this.ProductRepository = ProductRepository;
        }

        public async Task<List<ProductListVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await this.ProductRepository.ListAllAsync()).OrderBy(x => x.Name);
            return this.mapper.Map<List<ProductListVm>>(allProducts);
        }

    }
}