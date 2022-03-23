using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Language.TriManiaV1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, CreateOrderResponse>
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IOrderItemRepository _orderItemRepository;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public CreateOrderHandler(IUserRepository userRepository,IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateOrderResponse> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<string> validations = new List<string>();
                
                var isUserExist = await _userRepository.GetById(request.UserId);

                if (isUserExist is null)
                    throw new Exception(CreateOrderMsg.CreateOrderValidationError_0004);

                var isOrderProgress = await _orderRepository.GetOpenOrderByUserId(request.UserId);

                if (!(isOrderProgress is null))
                    throw new Exception(String.Format(CreateOrderMsg.CreateOrderValidationError_0003, isOrderProgress.Id));

                List<OrderItem> items = new List<OrderItem>();

                foreach (var item in request.Items)
                {
                    var isProductExist = await _productRepository.GetById(item.ProductId);

                    if(isProductExist is null)
                    {
                        validations.Add(string.Format(CreateOrderMsg.CreateOrderValidationError_0001, item.ProductId));
                        continue;
                    }

                    if (!isProductExist.HasStock(item.Quantity))
                    {
                        validations.Add(string.Format(CreateOrderMsg.CreateOrderValidationError_0002, item.ProductId));
                        continue;
                    }

                    items.Add(_mapper.Map<OrderItem>(item));
                }

                if (!validations.Count.Equals(0))
                    return BadSuccessResponse(validations);

                Order order = _mapper.Map<Order>(request);

                order.CalculateTotalOrder(items);
                order.SetStatusOrder(OrderStatus.Open);

                await _orderRepository.Create(order);

                foreach(var item in items)
                {
                    item.SetOrderId(order.Id);

                    await _orderItemRepository.Create(item);
                }

                return SuccessResponse(order,items);
            }
            catch (Exception ex)
            {
                return NotSucessResponse(ex.Message);
            }
        }

        public CreateOrderResponse SuccessResponse(Order order, List<OrderItem> orderItems)
        {
            List<object> items = new List<object>();

            foreach (var item in orderItems)
                items.Add(new { item.Id, item.ProductId, item.Price, item.Quantity });

            return new CreateOrderResponse()
            {
                Success = true,
                Result = new { 
                    Order = new {
                        order.Id,
                        order.UserId,
                        order.Status,
                        order.Type,
                        items,
                        order.CreateDate
                    }
                }
            };
        }

        public CreateOrderResponse BadSuccessResponse(List<string> validations)
            => new CreateOrderResponse()
            {
                Success = false,
                Result = new { validations }
            };

        public CreateOrderResponse NotSucessResponse(string messege)
            => new CreateOrderResponse()
            {
                Success = false,
                Result = new { messege }
            };
    }
}
