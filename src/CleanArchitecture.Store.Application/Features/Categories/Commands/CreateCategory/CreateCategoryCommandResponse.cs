using CleanArchitecture.Store.Application.Responses;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        public CreateCategoryCommandResponse() : base()
        {
        }

        public CreateCategoryDto Category { get; set; }
    }
}