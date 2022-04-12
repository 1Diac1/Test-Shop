using Microsoft.AspNetCore.Authentication.JwtBearer;
using Test_Shop.Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Test_Shop.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Test_Shop.WebAPI.Identity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IIdentityService _identityService;

        public AuthenticationController(
            IRefreshTokenService refreshTokenService, 
            IIdentityService identityService)
        {
            _refreshTokenService = refreshTokenService;
            _identityService = identityService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await _identityService.LoginAsync(request);

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _identityService.RegisterAsync(request);

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequest request)
        {
            var result = await _identityService.RefreshTokenAsync(request);

            return Ok(request);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var userId = HttpContext.User.FindFirstValue("id");

            if (userId is null)
                return Unauthorized();

            var result = await _refreshTokenService.DeleteAllAsync(userId);

            return result is true ? (IActionResult) NoContent() : BadRequest();
        }
    }
}
