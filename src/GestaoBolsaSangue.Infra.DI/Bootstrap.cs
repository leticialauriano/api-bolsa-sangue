using core.Patterns.EventSourcing;
using core.Patterns.EventSourcing.EventStore;
using core.Patterns.EventSourcing.EventStore.Context;
using core.Patterns.EventSourcing.EventStore.Repository;
using core.Patterns.MediatR;
using core.Repository.Mongo;
using core.Types;
using FluentValidation.Results;
using GestaoBolsaSangue.Application.Interfaces;
using GestaoBolsaSangue.Application.Services;
using GestaoBolsaSangue.Application.Shared.Mappers;
using GestaoBolsaSangue.Domain.Commands;
using GestaoBolsaSangue.Domain.Commands.Handler;
using GestaoBolsaSangue.Domain.Interfaces;
using GestaoBolsaSangue.Infra.Data.Http.Repository;
using GestaoBolsaSangue.Infra.Data.Respository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GestaoBolsaSangue.Infra.DI
{
    public class Bootstrap
    {
        private static IServiceCollection _services;
        private static string _hostProprietario;
        public static void Inicializar(IServiceCollection services, IConfiguration appSettings)
        {
            _services = services;
            _hostProprietario = appSettings.GetValue<string>("ExternalRepositories:Proprietario");

            RegistrarConfiguracoes();
            RegistrarEventStore();
            RegistrarApplication();
            RegistrarDomainCommands();
            RegistrarInfra();
        }

        private static void RegistrarEventStore()
        {
            //CORE CONFIGURATION
            _services.AddScoped<IEventStore, MongoEventStore>();
            _services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            _services.AddScoped<IEventStoreContext, EventStoreContext>();
        }

        private static void RegistrarConfiguracoes()
        {
            _services.AddScoped<IMediatorHandler, InMemoryBus>();
            _services.AddSingleton<AutoMapper.IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

        }

        private static void RegistrarDomainCommands()
        {
            _services.AddScoped<IRequestHandler<SalvarBolsaSangueCommand, ValidationResult>, BolsaSangueCommandHandler>();
        }

        private static void RegistrarApplication()
        {
            _services.AddTransient<IBolsaSangueService, BolsaSangueService>();
            _services.AddTransient<ITipoBolsaSangueService, TipoBolsaSangueService>();
            _services.AddTransient<IAnimalService, AnimalService>();
        }

        private static void RegistrarInfra()
        {
            _services.AddScoped<IMongoContext, Data.Context.BolsaSangueContext>();

            _services.AddScoped<IBolsaSangueRepository, BolsaSangueRepository>();
            _services.AddScoped<ITipoBolsaSangueRepository, TipoBolsaSangueRepository>();
            _services.AddScoped<IAnimalRepository, AnimalRepository>();

            _services.AddHttpClient<IProprietarioRepository, ProprietarioHttpRepository>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(_hostProprietario));
        }
    }
}
