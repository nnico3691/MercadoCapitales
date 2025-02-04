using AutoMapper;
using MediatR;
using MercadoCapitales.API.Clientes.Aplicacion;
using MercadoCapitales.API.Clientes.Models;
using MercadoCapitales.API.Clientes.Persistencia;
using MercadoCapitales.API.Clientes.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Primary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MercadoCapitales.API.Clientes
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
            //services.AddScoped<IEmailSenderService, EmailSenderService>();

            services.AddControllers()
                .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    });

            services.AddDbContext<ContextCliente>(opt => {
                opt.UseSqlServer(Configuration.GetConnectionString("ConexionDB"));
            });

            services.AddMediatR(typeof(Program).Assembly);
            services.AddAutoMapper(typeof(Program).Assembly);
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton<IEmailSenderService, EmailSenderService>();

            services.AddScoped<IMarketConnectService, PrimaryService>();

            // Acceder a la configuración de la API
            var apiIp = Configuration["ApiConfig:APIINSTRUMENTOS:Ip"];
            var apiPort = Configuration["ApiConfig:APIINSTRUMENTOS:Port"];

            // Registrar HttpClient
            services.AddHttpClient<IInstrumentService, InstrumentService>(client =>
            {
                client.BaseAddress = new Uri($"http://{apiIp}:{apiPort}/api/");
            });

            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.CustomSchemaIds(type => type.ToString());
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"API {groupName}",
                    Version = groupName,
                    Description = "API DE CLIENTES",
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
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API CLIENTES V1");
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
