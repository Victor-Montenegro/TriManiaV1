using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _mapper.Map<Product>(request);

                await ValidationProduct(product);

                await _productRepository.Create(product);

                return SuccessResponse(product);
            }
            catch (Exception ex)
            {
                return NotSuccessResponse(ex.Message);
            }
        }

        public async Task<bool> ValidationProduct(Product product)
        {
            var isNameProductExist = await _productRepository.GetProductByName(product.Name);

            if (!(isNameProductExist is null))
                throw new Exception("Esse Produto já foi cadastrado");

            return true;
        }

        public CreateProductResponse NotSuccessResponse(string message)
        {
            return new CreateProductResponse()
            {
                Success = false,
                Result = new { message }
            };
        }

        public CreateProductResponse BadSucessResponse(List<string> validations) 
        {
            return new CreateProductResponse()
            {
                Success = false,
                Result = new { validations }
            };
        }

        public CreateProductResponse SuccessResponse(Product product)
        {
            return new CreateProductResponse()
            {
                Success = true,
                Result = new { product = new { product.Id,product.Name,product.Description,product.Quantity,product.Price,product.CreateDate } }
            };
        }
    }
}
