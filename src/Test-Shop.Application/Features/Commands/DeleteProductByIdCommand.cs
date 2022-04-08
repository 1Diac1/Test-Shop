using System;
using MediatR;

namespace Test_Shop.Application.Features.Commands
{
    public class DeleteProductByIdCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public DeleteProductByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
