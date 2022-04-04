using Test_Shop.Entities.Models;

namespace Test_Shop.DomainServices.Interfaces
{
    public interface IOrderDomainService
    {
        decimal GetTotalPrice(Order order);
    }
}
