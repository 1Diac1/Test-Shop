using Test_Shop.Application.Features.Queries.Identity;
using Test_Shop.WebAPI.Contracts.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Test_Shop.WebAPI.Controllers
{
    public class AccountController : BaseApiController
    {

        [HttpGet(ApiRoutes.Account.ConfirmEmail)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            var query = new EmailConfirmationQuery(userId, token);
            await Mediator.Send(query);

            return NoContent();
        }
    }
}
