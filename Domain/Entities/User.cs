using Domain.Entities.Base;
using Domain.Enums;
using DomainService.Services.Security;
using System;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; }
        public string Login { get; private set; }
        public string Passworld { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDay { get; private set; }
        public UserType Type { get; private set; }

        public User(string name, string login, string cpf, string email, DateTime birthDay)
        {
            Name = name;
            Login = login;
            Cpf = cpf;
            Email = email;
            BirthDay = birthDay;
        }

        public void SetUserType(UserType type)
        {
            Type = type;
        }

        public User EncryptPassword(string passworld)
        {
            Passworld = CryptographyService.GenerateEncryptionSHA512(passworld);

            return this;
        }
    }
}
