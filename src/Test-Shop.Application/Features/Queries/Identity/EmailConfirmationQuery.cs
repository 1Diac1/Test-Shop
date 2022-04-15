using Test_Shop.Shared.Models;
using MediatR;

namespace Test_Shop.Application.Features.Queries.Identity
{
    public class EmailConfirmationQuery : IRequest<Result>
    {
        public string UserId { get; set; }
        public string Token { get; set; }

        public EmailConfirmationQuery(string userId, string token)
        {
            UserId = userId;
            Token = token;
        }
    }
}
