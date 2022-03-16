using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Mappers;
using Domain.Interfaces;
using System;

namespace Domain.Commands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = Mapper.CreateUserRequestToUser(request);

                var isExistEmail = await _userRepository.GetUserByEmail(user.Email);

                if (isExistEmail != null)
                    throw new Exception("Email informando já foi cadastrado");

                var isExistCpfOrCnpj = await _userRepository.GetUserByCpfOrCnpj(user.Cpf);

                if (isExistCpfOrCnpj != null)
                    throw new Exception("CPF/CNPJ informando já foi cadastrado");

                await _userRepository.Create(user);

                var response = new CreateUserResponse() {Success = true, Result = new { Success = true, User = user } };

                return response;
            }
            catch (Exception ex)
            {
                var response = new CreateUserResponse() { Success = false, Result = new { Validation = ex.Message} };

                return response;
            }
        }

        public async void Validations(User user)
        {
            var isExistEmail = await _userRepository.GetUserByEmail(user.Email);

            if (isExistEmail == null)
                throw new Exception("Email informando já foi cadastrado");

            var isExistCpfOrCnpj = await _userRepository.GetUserByCpfOrCnpj(user.Cpf);

            if (isExistCpfOrCnpj == null)
                throw new Exception("CPF/CNPJ informando já foi cadastrado");
        }
    }
}
