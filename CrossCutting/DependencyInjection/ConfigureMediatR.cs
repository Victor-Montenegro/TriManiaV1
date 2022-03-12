using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureMediatR
    {
        public static void ConfigureMedaitRSetup(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Domain");

            services.AddMediatR(assembly);
        }
    }
}
