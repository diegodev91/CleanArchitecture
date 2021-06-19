using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;
using CleanArchitecture.Store.Application.Exceptions;

namespace CleanArchitecture.Store.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IAsyncRepository<Product> productRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }


        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await productRepository.GetByIdAsync(request.Id).ConfigureAwait(false);

            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            var validationResult = await new UpdateProductCommandValidator().ValidateAsync(request).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            this.mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(Product));

            await this.productRepository.UpdateAsync(productToUpdate);

            return Unit.Value;
        }
    }
}