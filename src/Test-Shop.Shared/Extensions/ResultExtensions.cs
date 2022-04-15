using Test_Shop.Shared.Models;

namespace Test_Shop.Shared.Extensions
{
    public static class ResultExtensions
    {
        public static Result FailurePasswordMismatch(this Result result) =>
            Result.Failure("Password mismatch.");
    }
}
