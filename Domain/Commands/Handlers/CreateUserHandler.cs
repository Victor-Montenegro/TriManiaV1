using AutoMapper;
using Domain.Commands.Requests;
using Domain.Commands.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using DomainService.Services.Security;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        private IAddressRepository _addressRepository;

        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository,IAddressRepository addressRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                User user = _mapper.Map<User>(request);
                Address address = _mapper.Map<Address>(request);

                user.SetUserType(UserType.Client);
                user.EncryptPassword(request.Passworld);

                await ValidationUser(user);

                await _userRepository.Create(user);

                address.User = user;

                await _addressRepository.Create(address);

                return SuccessResponse(user,address);
            }
            catch (Exception ex)
            {
                return NotSuccesResponse(ex.Message);
            }
        }

        public async Task<bool> ValidationUser(User user)
        {
            var isExistLogin = await _userRepository.GetUserByLogin(user.Login);

            if (!(isExistLogin is null))
                throw new Exception("Esse login já existe");

            var isExistCpfOrCnpj = await _userRepository.GetUserByCpfOrCnpj(user.Cpf);

            if (!(isExistCpfOrCnpj is null))
                throw new Exception("CPF/CNPJ informando já foi cadastrado");

            return true;
        }

        private CreateUserResponse BadRequestResponse(List<string> validations)
        {
            return new CreateUserResponse(){
                Success = false,
                Result = new
                {
                    Validations = validations
                }
            };
        }

        private CreateUserResponse SuccessResponse(User user,Address address)
        {
            return new CreateUserResponse()
            {
                Success = true,
                Result = new {
                   user.Id,
                   user.Login,
                   user.Name,
                   user.Email,
                   user.Cpf,
                   user.BirthDay,
                   address = new
                   {
                       address.Neighborhood,
                       address.Street,
                       address.Number,
                       address.City,
                       address.State,
                   },
                   user.CreateDate,
                }
            };
        }

        private CreateUserResponse NotSuccesResponse(string message)
        {
            return new CreateUserResponse()
            {
                Success = false,
                Result = new
                {
                    Validation = message
                }
            };
        }
    }
}
