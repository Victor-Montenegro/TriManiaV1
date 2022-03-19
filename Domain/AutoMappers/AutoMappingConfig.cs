using AutoMapper;
using Domain.AutoMappers.Mappings;

namespace Domain.AutoMappers
{
    public class AutoMappingConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression cfg)
        {
            cfg.AllowNullCollections = true;

            cfg.AddProfile<UserMap>();
            cfg.AddProfile<AddressMap>();
        }
    }
}
