using AutoMapper.Configuration;
using Domain.Commands.Requests;
using Domain.Entities;

namespace Domain.AutoMappers.Mappings
{
    public class ProductMap : MapperConfigurationExpression
    {
        public ProductMap()
        {
            CreateMap<CreateProductRequest, Product>();
        }
    }
}
