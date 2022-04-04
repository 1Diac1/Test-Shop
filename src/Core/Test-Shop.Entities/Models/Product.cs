namespace Test_Shop.Entities.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
