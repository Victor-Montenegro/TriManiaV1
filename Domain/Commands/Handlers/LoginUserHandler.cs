using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Interfaces;
using DomainService.Services.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private IUserRepository _userRepository;
        private SigningConfigurationService _signingConfigurationService;

        public LoginUserHandler(IUserRepository userRepository, SigningConfigurationService signingConfigurationService)
        {
            _userRepository = userRepository;
            _signingConfigurationService = signingConfigurationService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                request.Passworld = CryptographyService.GenerateEncryptionSHA512(request.Passworld);

                User isUserExist = await _userRepository.GetUserByLoginAndPassworld(request.Login, request.Passworld);

                List<string> validations = new List<string>();

                if (isUserExist is null)
                    validations.Add("Login ou senha incorretos");

                if (!validations.Count.Equals(0))
                    return BadSucessResponse(validations);

                string token = TokenService.GenerateToken(isUserExist.Id.ToString(),isUserExist.Type.ToString(), _signingConfigurationService);

                return SuccessResponse(isUserExist,token);

            }
            catch (Exception ex)
            {
                return NotSucessResponse("Não foi possivel realizar o login, tente novamente mais tarde");
            }
        }

        private LoginUserResponse BadSucessResponse(List<string> validations)
        {
            return new LoginUserResponse()
            {
                Success = false,
                Result = new { validations }
            };
        }

        public LoginUserResponse SuccessResponse(User user,string token)
        {
            return new LoginUserResponse()
            {
                Success = true,
                Result = new
                {
                    user = new { userId = user.Id, user.Login },
                    token
                }
            };
        }

        public LoginUserResponse NotSucessResponse(string message)
        {
            return new LoginUserResponse()
            {
                Success = false,
                Result = new { message }
            };
        }
    }
}
