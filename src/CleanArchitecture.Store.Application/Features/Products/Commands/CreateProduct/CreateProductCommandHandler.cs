using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;

namespace CleanArchitecture.Store.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IAsyncRepository<Product> productRepository;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(IAsyncRepository<Product> productRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }


        public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var CreateProductCommandResponse = new CreateProductCommandResponse();

            var validationResult = await new CreateProductCommandValidator().ValidateAsync(request).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                CreateProductCommandResponse.Success = false;
                CreateProductCommandResponse.ValidationErrors = (from error in validationResult.Errors
                                                                 select error.ErrorMessage).ToList();
            }
            if (CreateProductCommandResponse.Success)
            {
                var product = this.mapper.Map<Product>(request);
                product = await productRepository.AddAsync(product);
                CreateProductCommandResponse.Product = mapper.Map<CreateProductDto>(product);
            }

            return CreateProductCommandResponse;
        }
    }
}