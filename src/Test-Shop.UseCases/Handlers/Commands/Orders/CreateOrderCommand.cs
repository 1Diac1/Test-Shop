using MediatR;
using Test_Shop.UseCases.Handlers.Dto;

namespace Test_Shop.UseCases.Handlers.Commands.Orders
{
    public class CreateOrderCommand : IRequest
    {
        public CreateOrderDto Dto { get; set; }
    }
}
