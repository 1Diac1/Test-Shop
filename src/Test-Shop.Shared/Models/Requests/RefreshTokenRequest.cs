using System.ComponentModel.DataAnnotations;

namespace Test_Shop.Shared.Models.Requests
{
    public class RefreshTokenRequest
    {
        [Required] 
        public string RefreshToken { get; set; }
    }
}
