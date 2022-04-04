namespace Test_Shop.Entities.Models
{
    public class RefreshToken : BaseModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
