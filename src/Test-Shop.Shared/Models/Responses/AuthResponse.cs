using System.Collections.Generic;

namespace Test_Shop.Shared.Models.Responses
{
    public class AuthResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public AuthResponse()
        {
        }

        public AuthResponse(bool success)
            : base(success)
        {
        }

        public AuthResponse(IEnumerable<string> errors)
            : base(errors)
        {
        }

        public AuthResponse(string error)
            : base(error)
        {
        }
    }
}
