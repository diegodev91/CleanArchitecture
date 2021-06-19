using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Store.Application.Features.Products.Commands.DeleteProduct;
using CleanArchitecture.Store.Application.Features.Products.Commands.UpdateProduct;
using CleanArchitecture.Store.Application.Features.Products.Queries.GetProductById;
using CleanArchitecture.Store.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Store.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateProductCommandResponse>> Create([FromBody] CreateProductCommand createProductCommand)
        {
            var response = await this.mediator.Send(createProductCommand);
            return Ok(response);
        }

        [HttpPut("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateProductCommand updateProductCommand)
        {
            updateProductCommand.Id = id;
            var response = await this.mediator.Send(updateProductCommand);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await this.mediator.Send(new DeleteProductCommand() { Id = id });
            return NoContent();
        }

        [HttpGet("Get/{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var dto = await this.mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(dto);
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductListVm>>> GetAllCategories()
        {
            var dtos = await this.mediator.Send(new GetProductListQuery());
            return Ok(dtos);
        }
    }
}