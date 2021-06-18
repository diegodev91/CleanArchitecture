using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }


        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateCategoryCommandResponse();

            var validationResult = await new CreateCategoryCommandValidator().ValidateAsync(request).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.ValidationErrors = (from error in validationResult.Errors
                                                                  select error.ErrorMessage).ToList();
            }
            if (createCategoryCommandResponse.Success)
            {
                var category = new Category() { Name = request.Name, Provider = request.Provider, EndOfContract = request.EndOfContract };
                category = await categoryRepository.AddAsync(category);
                createCategoryCommandResponse.Category = mapper.Map<CreateCategoryDto>(category);
            }

            return createCategoryCommandResponse;
        }
    }
}