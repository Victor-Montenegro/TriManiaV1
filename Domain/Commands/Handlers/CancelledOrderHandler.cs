using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Language.TriManiaV1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CancelledOrderHandler : IRequestHandler<CancelledOrderRequest, CancelledOrderResponse>
    {

        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;

        public CancelledOrderHandler(IOrderRepository orderRepository,IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public async Task<CancelledOrderResponse> Handle(CancelledOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await ValidationUserAndOrder(request.UserId);

                order.CancelledOrder();

                await _orderRepository.Update(order);

                return SuccessResponse(string.Format(CancelledOrderMsg.CancelledOrder_Success_00001, order.Id));
            }
            catch(DBConcurrencyException ex)
            {
                return NotSuccessResponse(HandlerMsg.Handler_Errors_00001);
            }
            catch (Exception ex)
            {
                return NotSuccessResponse(ex.Message);
            }
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


        public CancelledOrderResponse SuccessResponse(string message)
            => new CancelledOrderResponse() { Success = true, Result = new { message } };

        public CancelledOrderResponse NotSuccessResponse(string message)
            => new CancelledOrderResponse() { Success = false, Result = new { message } };

        public CancelledOrderResponse BadSuccessResponse(List<string> validations)
            => new CancelledOrderResponse() { Success = false, Result = new { validations } };
    }
}
