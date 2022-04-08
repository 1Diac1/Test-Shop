using System.Collections.Generic;

namespace Test_Shop.Shared.Models.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public BaseResponse()
        {
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }

        public BaseResponse(IEnumerable<string> errors)
        {
            Errors = errors;
            Success = false;
        }

        public BaseResponse(string error)
        {
            Errors = new[] {error};
            Success = false;
        }
    }
}
