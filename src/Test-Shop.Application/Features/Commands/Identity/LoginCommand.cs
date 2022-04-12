using Test_Shop.Infrastructure.Interfaces.Mappings;
using Test_Shop.Shared.Models.Requests;
using Test_Shop.Shared.Models;
using MediatR;

namespace Test_Shop.Application.Features.Commands.Identity
{
    public class LoginCommand : IRequest<Result>, IMapFrom<LoginRequest>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
