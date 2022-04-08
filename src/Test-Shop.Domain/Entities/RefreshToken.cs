using System;

namespace Test_Shop.Domain.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }

        public RefreshToken()
        {
            Id = Guid.NewGuid();
        }

        public RefreshToken(string token, string userId)
        {
            Token = token;
            UserId = userId;
        }
    }
}
