using Microsoft.AspNetCore.Identity;
using Test_Shop.Shared.Models;
using System.Linq;

namespace Test_Shop.Infrastructure.Implementation.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result) =>
            result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
