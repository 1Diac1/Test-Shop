using MediatR;
using Test_Shop.UseCases.Handlers.Dto;

namespace Test_Shop.UseCases.Handlers.Queries.Orders.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
