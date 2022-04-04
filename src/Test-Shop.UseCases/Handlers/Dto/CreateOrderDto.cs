using Test_Shop.Entities.Models;
using Test_Shop.Infrastructure.Interfaces.Mappings;

namespace Test_Shop.UseCases.Handlers.Dto
{
    public class CreateOrderDto : IMapWith<Order>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
    }
}
