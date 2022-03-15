using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateProductCommandHandler(
            ILogger<CreateProductCommandHandler> logger,
            IMapper mapper, 
            IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            var response = await _productRepository.CreateAsync(product);

            if (response.Success is false)
                return response;

            _logger.LogInformation($"Create Entity: Product had been successfully created ({DateTime.Now:G}).");

            return response;
        }
    }
}
