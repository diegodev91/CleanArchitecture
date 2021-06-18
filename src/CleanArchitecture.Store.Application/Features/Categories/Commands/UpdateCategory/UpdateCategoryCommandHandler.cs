using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }


        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var UpdateCategoryCommandResponse = new UpdateCategoryCommandResponse();

            var validationResult = await new UpdateCategoryCommandValidator().ValidateAsync(request).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                UpdateCategoryCommandResponse.Success = false;
                UpdateCategoryCommandResponse.ValidationErrors = (from error in validationResult.Errors
                                                                  select error.ErrorMessage).ToList();
            }
            if (UpdateCategoryCommandResponse.Success)
            {
                var category = new Category() { Name = request.Name, Provider = request.Provider, EndOfContract = request.EndOfContract };
                await categoryRepository.UpdateAsync(category);
                UpdateCategoryCommandResponse.Success = true;
            }

            return UpdateCategoryCommandResponse;
        }
    }
}