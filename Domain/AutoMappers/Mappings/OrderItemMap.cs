using AutoMapper.Configuration;
using Domain.Entities;
using Domain.Models;

namespace Domain.AutoMappers.Mappings
{
    public class OrderItemMap : MapperConfigurationExpression
    {
        public OrderItemMap()
        {
            CreateMap<OrderItemRequest, OrderItem>()
                .ReverseMap();
        }
    }
}
