using AutoMapper;
using MediatR;
using MercadoCapitales.API.Precios.Aplicacion;
using MercadoCapitales.API.Precios.Persistencia;
using MercadoCapitales.API.Precios.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Precios
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

            services.AddDbContext<Context>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDB"));
            });

            services.AddMediatR(typeof(Program).Assembly);
            services.AddAutoMapper(typeof(Program));

            // Acceder a la configuración de la API
            var apiIp = Configuration["ApiConfig:APIPRECIO:Ip"];
            var apiPort = Configuration["ApiConfig:APIPRECIO:Port"];

            // Registrar HttpClient
            services.AddHttpClient<IInstrumentService, InstrumentService>(client =>
            {
                client.BaseAddress = new Uri($"http://{apiIp}:{apiPort}/api/");
            });

            // Agregar soporte de WebSockets
            services.AddWebSockets(options =>
            {
                options.KeepAliveInterval = TimeSpan.FromSeconds(120);
            });

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API {groupName}",
                    Version = groupName,
                    Description = "API DE PRECIOS",
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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory serviceScopeFactory, IInstrumentService instrument, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API PRECIOS V1");
            });

            Socket socket = new Socket(Configuration,serviceScopeFactory, instrument, mapper);

            ThreadPool.QueueUserWorkItem(_ =>
            {
                socket.RunSocket(new object[] { }).GetAwaiter().GetResult();
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
