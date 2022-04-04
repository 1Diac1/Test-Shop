using System.Collections.Generic;
using MediatR;
using Test_Shop.UseCases.Handlers.Dto;

namespace Test_Shop.UseCases.Handlers.Queries.Orders.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<ICollection<OrderDto>>
    {
        
    }
}
