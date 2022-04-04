using System;
using System.Collections.Generic;

namespace Test_Shop.Entities.Models
{
    public class Order : BaseModel
    {
        public DateTime CreationDate { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
