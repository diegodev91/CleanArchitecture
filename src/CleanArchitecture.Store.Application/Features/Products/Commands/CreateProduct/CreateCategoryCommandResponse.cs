using CleanArchitecture.Store.Application.Responses;

namespace CleanArchitecture.Store.Application.Features.Categories.Commands.CreateProduct
{
    public class CreateProductCommandResponse : BaseResponse
    {
        public CreateProductCommandResponse() : base()
        {
        }

        public CreateProductDto Product { get; set; }
    }
}