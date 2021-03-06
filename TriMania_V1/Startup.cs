using CrossCutting.DependencyInjection;
using DomainService.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TriMania_V1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddControllers().ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext(connectionString);
            services.ConfigureAutorMapper();
            services.ConfigureMedaitRSetup();

            var signingConfigurationService = new SigningConfigurationService();

            services.AddSingleton(signingConfigurationService);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingConfigurationService.Key,
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

            services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("Versao01", new OpenApiInfo
                    {
                        Version = "TMv1",
                        Title = "TriMania - TriMania",
                    });

                    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "Conecte utilizando Token JWT",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });

                    x.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        { 
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });

                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/Versao01/swagger.json", "AspNetCore 3.1.21");
                x.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
