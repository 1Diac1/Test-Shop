using System;
using System.Collections.Generic;
using System.Linq;

namespace Test_Shop.Entities.Models
{
    public class Order : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public Order() =>
            CreationDate = DateTime.Now;
    }
}
