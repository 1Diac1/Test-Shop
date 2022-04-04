using FluentValidation;

namespace Test_Shop.UseCases.Handlers.Queries.Orders.GetOrderById
{
    public class GetOrderByIdValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdValidator()
        {
            RuleFor(order =>
                order.Id).NotEmpty();
        }
    }
}
