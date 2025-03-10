using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using GestaoBolsaSangue.Infra.DI;
using System.Collections.Generic;
using System.Globalization;

namespace GestaoBolsaSangue.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("pt-BR")
                };

                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            //WEB Api Config
            services.AddControllers();
            // Adding Swagger Configuration
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Gestão de Bolsa Sangue - Sangue Amigo",
                        Version = "v1",
                        Description = "API com responsabilidade de gerenciamento do âmbito de Bolsa de Sangues.",
                        Contact = new OpenApiContact
                        {
                            Name = "Leticia Lauriano da Silva",
                            Email = "leticia_lauriano@hotmail.com"
                        }
                    });
            });
            // Adding AutoMapper
            services.AddAutoMapper(typeof(Startup));
            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));
            // .NET DI Abstraction
            Bootstrap.Inicializar(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestLocalization();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API GestaoBolsaSangue");
                c.DisplayRequestDuration();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthorization();            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
