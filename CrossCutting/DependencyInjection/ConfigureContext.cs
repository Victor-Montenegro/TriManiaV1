using Core.Interfaces;
using Domain.Interfaces;
using Infrastructure.Dapper.Data;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureContext
    {
        public static void AddDbContext(this IServiceCollection services, string connectionStrings)
        {

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<TriManiaContext, TriManiaContext>();


            services.AddScoped<IUserRepositoryDP, UserRepositoryDP>();
            services.AddScoped<IOrderRepositoryDP, OrderRepositoryDP>();
            services.AddScoped<IProductRepositoryDP, ProductRepositoryDP>();

            services.AddDbContext<TriManiaContext>(options =>
                options.UseMySql(connectionStrings)
            );

        }
    }
}
