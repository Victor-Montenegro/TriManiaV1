using Domain.Entities.Base;
using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Login { get; set; }

        public string Passworld { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public DateTime BirthDay { get; set; }

        public UserType Type { get; set; }

    }
}
