using System.Collections.Generic;
using System;

namespace Test_Shop.Shared.Models
{
    public class Result
    {
        public IEnumerable<string> Errors { get; set; } = new List<string>();
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public bool Succeeded { get; set; }

        public Result()
        {
        }

        public Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        public Result(bool succeeded, string accessToken, string refreshToken)
        {
            Succeeded = succeeded;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public static Result Success() =>
            new Result(true, Array.Empty<string>());

        public static Result SuccessAuth(string accessToken, string refreshToken) =>
            new Result(true, accessToken, refreshToken);

        public static Result Failure(string error) =>
            new Result(false, new[] { error });

        public static Result Failure(IEnumerable<string> errors) =>
            new Result(false, errors);
    }
}
