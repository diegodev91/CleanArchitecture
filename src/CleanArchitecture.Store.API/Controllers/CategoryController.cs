using System.Threading.Tasks;
using CleanArchitecture.Store.Application.Features.Categories.Commands;
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
    }
}
