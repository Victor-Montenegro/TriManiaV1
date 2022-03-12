using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureContext
    {
        public static void AddDbContext(this IServiceCollection services, string connectionStrings)
        {
            services.AddDbContext<TriManiaContext>(options => options.UseSqlServer(connectionStrings));

            services.AddScoped<TriManiaContext,TriManiaContext>();
        }
    }
}
