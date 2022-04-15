using Test_Shop.Application.Features.Commands.Product;
using Test_Shop.Application.Features.Queries;
using Microsoft.AspNetCore.Authorization;
using Test_Shop.WebAPI.Contracts.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Test_Shop.Application.Features.Queries.Product;

namespace Test_Shop.WebAPI.Controllers
{
    [Authorize(Policy = "Admin")]
    public class ProductController : BaseApiController
    {
        [HttpGet( ApiRoutes.Product.GetAll)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var query = new GetAllProductsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet(ApiRoutes.Product.Get)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery] Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost(ApiRoutes.Product.Create)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPut(ApiRoutes.Product.Update)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(ApiRoutes.Product.Delete)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProductAsync([FromQuery] Guid id)
        {
            var command = new DeleteProductByIdCommand(id);
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
