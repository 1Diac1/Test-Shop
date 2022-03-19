using System.ComponentModel.DataAnnotations;

namespace Test_Shop.Application.Common.Models.Requests
{
    public class RefreshTokenRequest
    {
        [Required] 
        public string RefreshToken { get; set; }
    }
}
