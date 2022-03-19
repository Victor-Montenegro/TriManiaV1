using AutoMapper;
using Domain.AutoMappers;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureAutoMapper
    {
        public static void ConfigureAutorMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => 
                cfg.AddMaps(typeof(AutoMappingConfig).Assembly));

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
