using System.ComponentModel.DataAnnotations;

namespace Test_Shop.Entities.Models
{
    public class OrderDetails : BaseModel
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Range(1, 1000)]
        public int Count { get; set; }
    }
}
