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

                await _userRepository.Create(user);

                var response = new CreateUserResponse() { Result = new { Success = true, User = user } };

                return response;
            }
            catch (Exception ex)
            {
                var response = new CreateUserResponse() { Result = new { Success = false} };

                return response;
            }
        }
    }
}
