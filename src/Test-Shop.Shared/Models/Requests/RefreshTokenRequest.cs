namespace Test_Shop.Shared.Models.Requests
{
    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; }

        public RefreshTokenRequest(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
