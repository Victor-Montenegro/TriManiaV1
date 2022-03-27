using AutoMapper.Configuration;
using Domain.Entities;
using Domain.Models;

namespace Domain.AutoMappers.Mappings
{
    public class AddressMap : MapperConfigurationExpression
    {
        public AddressMap()
        {
            CreateMap<Address, AddressRequest>()
                .ReverseMap();
        }
    }
}
