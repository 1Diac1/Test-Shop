using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Features;
using MediatR;
using Microsoft.Extensions.Logging;
using Test_Shop.Application.Common.Models;
using Test_Shop.Application.Features.Commands;
using Test_Shop.Application.Interfaces.Repositories;
using Test_Shop.Domain.Entities;

namespace Test_Shop.Application.Features.Handlers
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, BaseResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateProductCommandHandler(
            ILogger<UpdateProductCommandHandler> logger,
            IMapper mapper,
            IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            var response = await _productRepository.UpdateAsync(product);

            if (response.Success is false)
                return response;

            _logger.LogInformation($"Update Entity: Product had been successfully updated ({DateTime.Now:G}).");

            return response;
        }
    }
}
