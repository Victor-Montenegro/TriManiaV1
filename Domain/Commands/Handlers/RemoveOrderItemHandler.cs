using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class RemoveOrderItemHandler : IRequestHandler<RemoveOrderItemRequest, RemoveOrderItemResponse>
    {

        private IOrderItemRepository _orderItemRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;

        public RemoveOrderItemHandler(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<RemoveOrderItemResponse> Handle(RemoveOrderItemRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await ValidationUserAndOrder(request.UserId);

                List<string> validations = new List<string>();

                foreach (var item in request.Items)
                {
                    string validationOrderItem = await ValidationOrderItem(item,order.Id);

                    if (!validationOrderItem.Length.Equals(0))
                    {
                        validations.Add(validationOrderItem);
                        continue;
                    }
                }

                if (!validations.Count.Equals(0))
                    return BadSuccessResponse(validations);

                await ValidationQuantityOrder(request.Items, order.Id);

                foreach(var item in request.Items)
                    await _orderItemRepository.Delete(item.OrderItemId);

                var orderItemsUpdated = await _orderItemRepository.GetAllOrderItemByOrderId(order.Id);

                order.CalculateTotalOrder(orderItemsUpdated);
                order.SetStatusOrder(OrderStatus.InProgress);

                await _orderRepository.Update(order);

                return SuccessResponse(order,orderItemsUpdated);
            }
            catch (DBConcurrencyException ex)
            {
                return NotSuccessResponse("Não foi possivel remove os itens da sua ordem, tente novamente mais tarde");
            }
            catch (Exception ex)
            {
                return NotSuccessResponse(ex.Message);
            }
        }

        public async Task<string> ValidationOrderItem(ListRemoveOrderItemRequest item,int orderId)
        {
            var isOrderItemExist = await _orderItemRepository.GetOrderItemByOrderItemIdAndOrderId(item.OrderItemId,orderId);

            if (isOrderItemExist is null)
                return string.Format("Não existe o item {0} no pedido {1}", item.OrderItemId,orderId);

            return string.Empty;
        }

        public async Task<bool> ValidationQuantityOrder(List<ListRemoveOrderItemRequest> items,int orderId) 
        {
            var quantityOrderItemExist = await _orderItemRepository.GetAllOrderItemByOrderId(orderId);

            if (quantityOrderItemExist.Count.Equals(items.Count))
                throw new Exception(string.Format("Não será possível remover todos os item do seu pedido {0}, pois deve ter ao menos um item cadastrado", orderId));

            return true;
        }

        public async Task<Order> ValidationUserAndOrder(int userId)
        {
            var isUserExist = await _userRepository.GetById(userId);

            if (isUserExist is null)
                throw new Exception("O usuario não existe");

            var isOrderExist = await _orderRepository.GetOpenOrderByUserId(userId);

            if (isOrderExist is null)
                throw new Exception("Não existe nenhum pedido em andamento");

            return isOrderExist;
        }

        public RemoveOrderItemResponse SuccessResponse(Order order, List<OrderItem> orderItems)
        {
            List<object> items = new List<object>();

            foreach (var item in orderItems)
                items.Add(new { item.Id, item.ProductId, item.Price, item.Quantity });

            return new RemoveOrderItemResponse()
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

        public RemoveOrderItemResponse BadSuccessResponse(List<string> validations)
            => new RemoveOrderItemResponse() { Success = false, Result = new { validations } };

        public RemoveOrderItemResponse NotSuccessResponse(string message)
            => new RemoveOrderItemResponse() {Success = false, Result = new { message } };
    }
}
