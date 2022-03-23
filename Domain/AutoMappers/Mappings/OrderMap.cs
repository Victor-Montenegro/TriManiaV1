using AutoMapper.Configuration;
using Domain.Commands.Requests;
using Domain.Entities;

namespace Domain.AutoMappers.Mappings
{
    public class OrderMap : MapperConfigurationExpression
    {
        public OrderMap()
        {
            CreateMap<CreateOrderRequest, Order>()
                .ReverseMap();
        }
    }
}
