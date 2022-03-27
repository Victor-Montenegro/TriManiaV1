using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Language.TriManiaV1;
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

                User user = await ValidationLogin(request);

                string token = TokenService.GenerateToken(user.Id.ToString(), user.Type.ToString(), _signingConfigurationService);

                return SuccessResponse(user, token);

            }
            catch (Exception ex)
            {
                return NotSucessResponse(ex.Message);
            }
        }

        public async Task<User> ValidationLogin(LoginUserRequest request)
        {
            User isUserExist = await _userRepository.GetUserByLoginAndPassworld(request.Login, request.Passworld);

            if (isUserExist is null)
                throw new Exception(LoginUserMsg.LoginUser_NotSuccess_0001);

            return isUserExist;
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
