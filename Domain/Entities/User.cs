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

        public User(string name, string login, string passworld, string cpf, string email, DateTime birthDay)
        {
            Name = name;
            Login = login;
            Passworld = passworld;
            Cpf = cpf;
            Email = email;
            BirthDay = birthDay;
        }

        public void SetUserType(UserType type)
        {
            Type = type;
        }

        public void EncryptPassword()
        {
            Passworld = CryptographyService.GenerateEncryptionSHA512(Passworld);
        }

    }
}
