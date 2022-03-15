

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Application.Interfaces.Repositories;

namespace Test_Shop.Application.Features.Handlers
{
    public class DeleteProductByIdCommandHandler 
        : IRequestHandler<DeleteProductByIdCommand, BaseResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DeleteProductByIdCommandHandler(
            IProductRepository productRepository, 
            IMapper mapper, 
            ILogger<DeleteProductByIdCommand> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<BaseResponse> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _productRepository.DeleteAsync(request.Id);

            if (response.Success is false)
                return response;

            _logger.LogInformation($"Delete Entity: Product had been successfully deleted ({DateTime.Now:G}).");

            return response;
        }
    }
}
