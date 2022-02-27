using MDDPlatform.DataStorage.SQLDB;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Application.Queries.Handlers;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Domains.Application.Services;
using MDDPlatform.Domains.Infrastructure.Data.Context;
using MDDPlatform.Domains.Infrastructure.Data.Repositories;
using MDDPlatform.Domains.Infrastructure.Initializers;
using MDDPlatform.Domains.Services.Commands;
using MDDPlatform.Domains.Services.Commands.Handlers;
using MDDPlatform.Domains.Services.ExternalEvents;
using MDDPlatform.Domains.Services.ExternalEvents.Handlers;
using MDDPlatform.Domains.Services.Repositories;
using MDDPlatform.Messages.Brokers;
using MDDPlatform.Messages.Commands;
using MDDPlatform.Messages.Events;
using MDDPlatform.Messages.Queries;
using MDDPlatform.SharedKernel.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDDPlatform.Domains.Infrastructure{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration){
            services.AddHostedService<AppInitializer>();

            services.AddRabbitMQ(configuration,"rabbitmq");

            services.AddSqlDBContext<WriteContext>(configuration,"sqlserver");
            services.AddSqlDBContext<ReadContext>(configuration,"sqlserver");

            services.AddScoped<IDomainWriter, DomainWriter>();
            services.AddScoped<IDomainReader,DomainReader>();

            services.AddSingleton<IDomainService,DomainService>();

            services.AddSingleton<IEventMapper,DefaultEventMapper>();

            services.AddScoped<IQueryHandler<GetAllModels,IList<ModelDto>>,GetAllModelsHandler>();
            services.AddScoped<IQueryHandler<GetDomain, DomainDto>,GetDomainHandler>();
            services.AddScoped<IQueryHandler<GetModel, ModelDto>,GetModelHandler>();
            services.AddScoped<IQueryHandler<GetModelsByName, IList<ModelDto>>,GetModelByIdHandler>();

            services.AddScoped<ICommandHandler<CreateModel>,CreateModelHandler>();

            services.AddScoped<IEventHandler<ProblemDomainDecomposed>,ProblemDomainDecomposedHandler>();


            return services;
        }
    }
}