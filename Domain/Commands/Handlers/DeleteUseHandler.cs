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
    public class DeleteUseHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {

        private IUserRepository _userRepository;
        private IOrderRepository _orderRepository;
        private IAddressRepository _addressRepository;

        public DeleteUseHandler(IAddressRepository addressRepository, IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await ValidationUserAndOrder(request.UserId);
                Address address = await _addressRepository.GetAddressByUserId(user.Id);

                await _userRepository.Delete(user.Id);
                await _addressRepository.Delete(address.Id);


                return SuccessResponse(string.Format("Usuário {0} removido com sucesso",user.Id));
            }
            catch (DBConcurrencyException ex)
            {
                return NotSucessResponse("Não foi possivel remover o usuário");
            }
            catch (Exception ex)
            {
                return NotSucessResponse(ex.Message);
            }
        }

        public async Task<User> ValidationUserAndOrder(int userId)
        {
            var isUserExist = await _userRepository.GetById(userId);

            if (isUserExist is null)
                throw new Exception("O Usuário informado não existe");

            var isOrderOpen = await _orderRepository.GetOpenOrderByUserId(userId);

            if (!(isOrderOpen is null))
                throw new Exception(string.Format("O Usuário não pode ser removido enquanto tiver a ordem {0} aberta", isOrderOpen.Id));

            return isUserExist;
        }

        public DeleteUserResponse SuccessResponse(string message)
            => new DeleteUserResponse()
            {
                Success = true,
                Result = new
                {
                    message
                }
            };

        public DeleteUserResponse BadSuccessResponse(List<string> validations)
            => new DeleteUserResponse()
            {
                Success = false,
                Result = new { validations }
            };

        public DeleteUserResponse NotSucessResponse(string messege)
            => new DeleteUserResponse()
            {
                Success = false,
                Result = new { messege }
            };
    }
}
