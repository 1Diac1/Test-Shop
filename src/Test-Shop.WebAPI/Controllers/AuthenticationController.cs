using Test_Shop.Application.Features.Commands.Identity;
using Test_Shop.WebAPI.Contracts.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Test_Shop.WebAPI.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        [HttpPost(ApiRoutes.Authentication.Login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost(ApiRoutes.Authentication.Register)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Authentication.Logout)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LogoutAsync(LogoutCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPost(ApiRoutes.Authentication.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
