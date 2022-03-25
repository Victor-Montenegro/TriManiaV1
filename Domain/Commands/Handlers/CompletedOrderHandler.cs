using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CompletedOrderHandler : IRequestHandler<CompletedOrderRequest, CompletedOrderResponse>
    {
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;

        public CompletedOrderHandler(IProductRepository productRepository, 
            IUserRepository userRepository, IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }
        public async Task<CompletedOrderResponse> Handle(CompletedOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<string> validations = new List<string>();
                Order order = await ValidationUserAndOrder(request.UserId);

                List<OrderItem> orderItems = await _orderItemRepository.GetAllOrderItemByOrderId(order.Id);

                foreach (var item in orderItems)
                {
                    string validationProduct = await ValidationProduct(item);

                    if (!validationProduct.Length.Equals(0))
                        validations.Add(validationProduct);
                }

                if (!validations.Count.Equals(0))
                    return BadSuccessResponse(validations);

                foreach(var item in orderItems)
                {
                    var product = await _productRepository.GetById(item.ProductId);

                    product.SellProduct(item.Quantity);

                    await _productRepository.Update(product);
                }

                order.SetPaymentType(request.Type.Value);
                order.CompletedOrder();

                await _orderRepository.Update(order);

                return SuccessResponse(string.Format("O pedido {0} foi completado com sucesso",order.Id));
            }
            catch (DBConcurrencyException ex)
            {
                return NotSuccessResponse("Não foi possivel completa a sua ordem, tente novamente mais tarde");
            }
            catch (Exception ex)
            {
                return NotSuccessResponse(ex.Message);
            }
        }

        public async Task<string> ValidationProduct(OrderItem item)
        {
            var product = await _productRepository.GetById(item.ProductId);

            if (!product.HasStock(item.Quantity))
                return string.Format("o item {0} com o productId {1} não tem estoque suficiente",item.Id,product.Id);

            return string.Empty;
        }

        public async Task<Order> ValidationUserAndOrder(int userId)
        {
            var isUserExist = await _userRepository.GetById(userId);

            if (isUserExist is null)
                throw new Exception("O usuário informado não existe");

            var isOrderExist = await _orderRepository.GetOpenOrderByUserId(userId);

            if (isOrderExist is null)
                throw new Exception("Não existe nenhum pedido em andamento");

            return isOrderExist;
        }

        public CompletedOrderResponse NotSuccessResponse(string message)
    => new CompletedOrderResponse() { Success = false, Result = new { message } };

        public CompletedOrderResponse BadSuccessResponse(List<string> validations)
            => new CompletedOrderResponse() { Success = false, Result = new { validations } };

        public CompletedOrderResponse SuccessResponse(string message)
            => new CompletedOrderResponse() { Success = true, Result = new { message } };
    }
}
