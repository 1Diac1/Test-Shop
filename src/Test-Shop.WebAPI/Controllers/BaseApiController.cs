using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Test_Shop.WebAPI.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
