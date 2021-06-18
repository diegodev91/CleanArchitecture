using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Store.Application.Contracts.Persistence;
using CleanArchitecture.Store.Domain.Entities;
using MediatR;
using System.Linq;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryCommandHandler(IAsyncRepository<Category> categoryRepository,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }


        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteCategoryCommandResponse = new DeleteCategoryCommandResponse();

            await categoryRepository.DeleteAsync(await categoryRepository.GetByIdAsync(request.Id).ConfigureAwait(false));
            deleteCategoryCommandResponse.Success = true;

            return deleteCategoryCommandResponse;
        }
    }
}