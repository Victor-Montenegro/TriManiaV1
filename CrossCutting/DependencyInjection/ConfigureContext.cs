using Domain.Interfaces;
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

            services.AddScoped<TriManiaContext, TriManiaContext>();

            services.AddDbContext<TriManiaContext>(options =>
                options.UseSqlServer(connectionStrings)
               );

        }
    }
}
