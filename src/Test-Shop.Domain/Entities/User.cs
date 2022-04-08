using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Test_Shop.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
