using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Features.Categories.Commands.CreateCategory;
using CleanArchitecture.Store.Application.Features.Categories.Commands.DeleteCategory;
using CleanArchitecture.Store.Application.Features.Categories.Commands.UpdateCategory;
using CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryById;
using CleanArchitecture.Store.Application.Features.Categories.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var response = await this.mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            updateCategoryCommand.Id = id;
            var response = await this.mediator.Send(updateCategoryCommand);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await this.mediator.Send(new DeleteCategoryCommand() { Id = id });
            return NoContent();
        }

        [HttpGet("Get/{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryProductListVm>>> Get(int id)
        {
            var dtos = await this.mediator.Send(new GetCategoryListWithProductsQuery() { Id = id });
            return Ok(dtos);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var dtos = await this.mediator.Send(new GetCategoryListQuery());
            return Ok(dtos);
        }
    }
}
