using System;
using MediatR;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Common.Models.Responses;

namespace Test_Shop.Application.Features.Commands
{
    public class DeleteProductByIdCommand : IRequest<BaseResponse>
    {
        public Guid Id { get; set; }

        public DeleteProductByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
