using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;
using CleanArchitecture.Store.Application.Exceptions;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IAsyncRepository<Category> categoryRepository;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await categoryRepository.GetByIdAsync(request.Id).ConfigureAwait(false);
            if (categoryToDelete == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            await categoryRepository.DeleteAsync(categoryToDelete).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}