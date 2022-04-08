namespace Test_Shop.Infrastructure.Implementation.Settings
{
    public class JwtConfiguration
    {
        public double RefreshTokenExpirationMinutes { get; set; }
        public double AccessTokenExpirationMinutes { get; set; }
        public string RefreshTokenSecret { get; set; }
        public string AccessTokenSecret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
    }
}
