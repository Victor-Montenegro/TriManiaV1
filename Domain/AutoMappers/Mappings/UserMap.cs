using AutoMapper.Configuration;
using Domain.Commands.Requests;
using Domain.Entities;

namespace Domain.AutoMappers.Mappings
{
    public class UserMap : MapperConfigurationExpression
    {
        public UserMap()
        {
            CreateMap<User, CreateUserRequest>()
                .ReverseMap();
        }
    }
}
