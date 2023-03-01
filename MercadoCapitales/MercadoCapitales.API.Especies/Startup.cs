using AutoMapper;
using MediatR;
using MercadoCapitales.API.Especies.Aplicacion;
using MercadoCapitales.API.Especies.Persistencia;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace MercadoCapitales.API.Especies
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
            services.AddControllers();
            services.AddDbContext<ContextEspecie>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDB"));
            });
            services.AddMediatR(typeof(CrearAllInstruments.Manejador).Assembly);
            services.AddAutoMapper(typeof(ConsultaFuturosFinancieros.Manejador));

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API {groupName}",
                    Version = groupName,
                    Description = "API DE ESPECIES",
                    Contact = new OpenApiContact
                    {
                        Name = "Mercado Capitales",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API ESPECIES V1");
            });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
