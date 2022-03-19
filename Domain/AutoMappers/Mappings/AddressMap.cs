using AutoMapper.Configuration;
using Domain.Commands.Requests;
using Domain.Entities;

namespace Domain.AutoMappers.Mappings
{
    public class AddressMap : MapperConfigurationExpression
    {
        public AddressMap()
        {
            CreateMap<Address, CreateUserRequest>()
                .ForPath(x => x.Address.Neighborhood, map => map.MapFrom(a => a.Neighborhood))
                .ForPath(x => x.Address.Number, map => map.MapFrom(a => a.Number))
                .ForPath(x => x.Address.State, map => map.MapFrom(a => a.State))
                .ForPath(x => x.Address.Street, map => map.MapFrom(a => a.Street))
                .ForPath(x => x.Address.City, map => map.MapFrom(a => a.City))
                .ReverseMap();
        }
    }
}
