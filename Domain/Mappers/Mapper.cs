using Domain.Commands.Requests;
using Domain.Entities;
using Domain.Security;
using System;

namespace Domain.Mappers
{
    public static class Mapper
    {
        public static User CreateUserRequestToUser(CreateUserRequest createUserRequest)
        {
            return new User()
            {
                Name = createUserRequest.Name,
                Login = createUserRequest.Login,
                Passworld = Cryptography.GenerateEncryptionSHA512(createUserRequest.Passworld),
                BirthDay = DateTime.Parse(createUserRequest.BirthDay),
                Cpf = createUserRequest.Cpf,
                Email = createUserRequest.Email,
                CreateDate = DateTime.Now
            };
        }
    }
}
