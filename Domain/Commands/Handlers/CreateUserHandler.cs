using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Mappers;

namespace Domain.Commands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        public Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            User user = Mapper.CreateUserRequestToUser(request);

            var response = new CreateUserResponse() { Result = new { Success = true, User = user} };

            return Task.FromResult(response);
        }
    }
}
