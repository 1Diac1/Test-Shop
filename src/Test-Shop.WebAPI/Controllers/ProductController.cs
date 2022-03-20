using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_Shop.Application.Common.Models.Requests;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Application.Features.Queries;

namespace Test_Shop.WebAPI.Controllers
{
    [Authorize(Policy = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);

            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductByIdAsync([FromBody] BaseRequest request)
        {
            var query = new GetProductByIdQuery(request.Id);
            var result = await _mediator.Send(query);

            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);

            return result.Success ? (IActionResult)NoContent() : BadRequest(result);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProductAsync([FromBody] BaseRequest request)
        {
            var command = new DeleteProductByIdCommand(request.Id);
            var result = await _mediator.Send(command);

            return result.Success ? (IActionResult) NoContent() : BadRequest(result);
        }
    }
}
