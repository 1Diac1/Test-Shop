using Test_Shop.Infrastructure.Interfaces.Mappings;
using Test_Shop.Shared.Models.Requests;
using Test_Shop.Shared.Models;
using MediatR;

namespace Test_Shop.Application.Features.Commands.Identity
{
    public class RegisterCommand : IRequest<Result>, IMapFrom<RegisterRequest>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
