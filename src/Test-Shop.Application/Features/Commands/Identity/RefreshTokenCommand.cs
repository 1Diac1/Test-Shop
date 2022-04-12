using Test_Shop.Infrastructure.Interfaces.Mappings;
using Test_Shop.Shared.Models.Requests;
using Test_Shop.Shared.Models;
using MediatR;

namespace Test_Shop.Application.Features.Commands.Identity
{
    public class RefreshTokenCommand : IRequest<Result>, IMapFrom<RefreshTokenRequest>
    {
        public string RefreshToken { get; set; }
    }
}
