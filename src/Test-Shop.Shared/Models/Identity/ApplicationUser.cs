using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Shared.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [JsonIgnore]
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
