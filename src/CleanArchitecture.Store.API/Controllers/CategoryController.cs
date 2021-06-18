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

        [HttpPost("Update")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UpdateCategoryCommandResponse>> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            var response = await this.mediator.Send(updateCategoryCommand);
            return Ok(response);
        }

        [HttpPost("Delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeleteCategoryCommandResponse>> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            var response = await this.mediator.Send(deleteCategoryCommand);
            return Ok(response);
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
