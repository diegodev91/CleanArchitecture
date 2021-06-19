using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;
using CleanArchitecture.Store.Application.Exceptions;

namespace CleanArchitecture.Store.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IAsyncRepository<Product> ProductRepository;

        public DeleteProductCommandHandler(IAsyncRepository<Product> ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }


        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var ProductToDelete = await ProductRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
            if (ProductToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            await ProductRepository.DeleteAsync(ProductToDelete).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}