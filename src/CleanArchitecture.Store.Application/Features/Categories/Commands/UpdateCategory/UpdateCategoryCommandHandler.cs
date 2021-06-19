using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;
using CleanArchitecture.Store.Application.Exceptions;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public UpdateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }


        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToUpdate = await categoryRepository.GetByIdAsync(request.Id).ConfigureAwait(false);

            if (categoryToUpdate == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            var validationResult = await new UpdateCategoryCommandValidator().ValidateAsync(request).ConfigureAwait(false);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            this.mapper.Map(request, categoryToUpdate, typeof(UpdateCategoryCommand), typeof(Category));

            await this.categoryRepository.UpdateAsync(categoryToUpdate);

            return Unit.Value;
        }
    }
}