using System.Linq;
using Test_Shop.DomainServices.Interfaces;
using Test_Shop.Entities.Models;

namespace Test_Shop.DomainServices.Implementation
{
    public class OrderDomainService : IOrderDomainService
    {
        public decimal GetTotalPrice(Order order) =>
            order.OrderItems.Sum(x => x.Count * x.Product.Price);
    }
}
