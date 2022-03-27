using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Language.TriManiaV1;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public CreateOrderHandler(IUserRepository userRepository, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IProductRepository productRepository, IMapper mapper)
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
                await ValidationUserAndOrder(request.UserId);
                ValidationItem(request.Items);

                List<string> validations = new List<string>();
                List<OrderItem> items = new List<OrderItem>();

                foreach (var item in request.Items)
                {
                    string validationProduct = await ValidationProduct(item);

                    if (!validationProduct.Length.Equals(0))
                    {
                        validations.Add(validationProduct);
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

                foreach (var item in items)
                {
                    item.SetOrderId(order.Id);

                    await _orderItemRepository.Create(item);
                }

                return SuccessResponse(order, items);
            }
            catch (Exception ex)
            {
                return NotSucessResponse(ex.Message);
            }
        }

        public void ValidationItem(List<OrderItemRequest> items)
        {
            foreach(var item in items)
            {
                if (!items.Count(x => x.ProductId == item.ProductId).Equals(1))
                    throw new Exception(string.Format(CreateOrderMsg.CreateOrder_NotSuccess_0004, item.ProductId));
            }              
        }

        public async Task<bool> ValidationUserAndOrder(int userId)
        {
            var isUserExist = await _userRepository.GetById(userId);

            if (isUserExist is null)
                throw new Exception(HandlerMsg.Handler_NotSuccess_Validations_00001);

            var isOrderProgress = await _orderRepository.GetOpenOrderByUserId(userId);

            if (!(isOrderProgress is null))
                throw new Exception(string.Format(CreateOrderMsg.CreateOrder_NotSuccess_0003, isOrderProgress.Id));

            return true;
        }

        public async Task<string> ValidationProduct(OrderItemRequest item)
        {
            var isProductExist = await _productRepository.GetById(item.ProductId);

            if (isProductExist is null)
                return string.Format(CreateOrderMsg.CreateOrder_NotSuccess_0001, item.ProductId);

            if (!isProductExist.HasStock(item.Quantity))
                return string.Format(CreateOrderMsg.CreateOrder_NotSuccess_0002, item.ProductId);

            return string.Empty;
        }

        public CreateOrderResponse SuccessResponse(Order order, List<OrderItem> orderItems)
        {
            List<object> items = new List<object>();

            foreach (var item in orderItems)
                items.Add(new { item.Id, item.ProductId, item.Price, item.Quantity });

            return new CreateOrderResponse()
            {
                Success = true,
                Result = new
                {
                    Order = new
                    {
                        order.Id,
                        order.UserId,
                        order.Status,
                        order.Type,
                        order.TotalValue,
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
