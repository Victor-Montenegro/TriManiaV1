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
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, UpdateOrderResponse>
    {
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;
        private IOrderItemRepository _orderItemRepository;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public UpdateOrderHandler(IProductRepository productRepository, IUserRepository userRepository, IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }


        public async Task<UpdateOrderResponse> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<string> validations = new List<string>();

                Order order = await ValidationUserAndOrder(request.UserId);
                List<OrderItem> orderItems = await _orderItemRepository.GetAllOrderItemByOrderId(order.Id);
                List<OrderItem> UpdateOrderItems = new List<OrderItem>();

                ValidationItem(request.Items);

                foreach (var item in request.Items)
                {
                    string validationProduct = await ValidationProduct(item);

                    if (!validationProduct.Length.Equals(0))
                    {
                        validations.Add(validationProduct);
                        continue;
                    }

                    UpdateOrderItems.Add(_mapper.Map<OrderItem>(item));
                }

                if (!validations.Count.Equals(0))
                    return BadSuccessResponse(validations);

                foreach (var item in UpdateOrderItems)
                {
                    var isItemOrderExist = await _orderItemRepository.GetOrderItemByOrderIdAndProductId(order.Id, item.ProductId);

                    if (isItemOrderExist is null)
                    {
                        item.SetOrderId(order.Id);
                        await _orderItemRepository.Create(item);
                    }
                    else
                    {
                        item.Id = isItemOrderExist.Id;
                        item.SetOrderId(order.Id);

                        await _orderItemRepository.Update(item);
                    } 
                }

                var orderItemsUpdated = await _orderItemRepository.GetAllOrderItemByOrderId(order.Id);

                order.CalculateTotalOrder(orderItemsUpdated);
                order.SetStatusOrder(OrderStatus.InProgress);

                await _orderRepository.Update(order);

                return SuccessResponse(order, orderItemsUpdated);
            }
            catch (DBConcurrencyException ex)
            {
                return NotSuccessResponse(HandlerMsg.Handler_Errors_00001);
            }
            catch (Exception ex)
            {
                return NotSuccessResponse(ex.Message);
            }
        }

        public void ValidationItem(List<OrderItemRequest> items)
        {
            foreach (var item in items)
            {
                if (!items.Count(x => x.ProductId == item.ProductId).Equals(1))
                    throw new Exception(string.Format(UpdateOrderMsg.UpdateOrder_NotSuccess_0001, item.ProductId));
            }
        }

        public async Task<string> ValidationProduct(OrderItemRequest item)
        {
            var isProductExist = await _productRepository.GetById(item.ProductId);

            if (isProductExist is null)
                return string.Format(UpdateOrderMsg.UpdateOrder_NotSuccess_0002, item.ProductId);

            if (!isProductExist.HasStock(item.Quantity))
                return string.Format(UpdateOrderMsg.UpdateOrder_NotSuccess_0003, item.ProductId);

            return string.Empty;
        }

        public async Task<Order> ValidationUserAndOrder(int userId)
        {
            var isUserExist = await _userRepository.GetById(userId);

            if (isUserExist is null)
                throw new Exception(HandlerMsg.Handler_NotSuccess_Validations_00001);

            var isOrderExist = await _orderRepository.GetOpenOrderByUserId(userId);

            if (isOrderExist is null)
                throw new Exception(HandlerMsg.Handler_NotSuccess_Validations_00002);

            return isOrderExist;
        }

        public UpdateOrderResponse SuccessResponse(Order order, List<OrderItem> orderItems)
        {
            List<object> items = new List<object>();

            foreach (var item in orderItems)
                items.Add(new { item.Id, item.ProductId, item.Price, item.Quantity });

            return new UpdateOrderResponse()
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

        public UpdateOrderResponse NotSuccessResponse(string message)
            => new UpdateOrderResponse() { Success = false, Result = new { message } };

        public UpdateOrderResponse BadSuccessResponse(List<string> validations)
            => new UpdateOrderResponse() { Success = false, Result = new { validations } };
    }
}
