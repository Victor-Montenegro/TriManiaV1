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

                var isNameProductExist = await _productRepository.GetProductByName(product.Name);

                List<string> validations = new List<string>();

                if (!(isNameProductExist is null))
                    validations.Add("Esse Produto já foi cadastrado");

                if (!validations.Count.Equals(0))
                    return BadSucessResponse(validations);

                await _productRepository.Create(product);

                return SuccessResponse(product);
            }
            catch (Exception ex)
            {
                return NotSuccessResponse("Não foi possível criar o produto.");
            }
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
