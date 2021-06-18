using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Store.Application.Features.Categories.Commands.DeleteCategory;
using CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await this.mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<UpdateCategoryCommandResponse>> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await this.mediator.Send(updateCategoryCommand);
            return Ok(response);
        }

        [HttpPost("Delete")]
        public async Task<ActionResult<DeleteCategoryCommandResponse>> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            var response = await this.mediator.Send(deleteCategoryCommand);
            return Ok(response);
        }
    }
}
