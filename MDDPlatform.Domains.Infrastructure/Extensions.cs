using MDDPlatform.DataStorage.MongoDB;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Interfaces;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Application.Queries.Handlers;
using MDDPlatform.Domains.Application.Services;
using MDDPlatform.Domains.Infrastructure.Initializers;
using MDDPlatform.Domains.Infrastructure.MongoDB;
using MDDPlatform.Domains.Infrastructure.MongoDB.Models;
using MDDPlatform.Domains.Infrastructure.Seeders;
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

namespace MDDPlatform.Domains.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration){
            services.AddHostedService<AppInitializer>();

            services.AddRabbitMQ(configuration,"rabbitmq");
            services.AddMongoDB(configuration,"mongodb");


            services.AddMongoRespository<DomainDocument,Guid>("Domains");
            services.AddMongoRespository<PackageDocument,Guid>("Packages");
            services.AddScoped<IDomainRepository, DomainRepository>();
            services.AddScoped<IDomainModelDataReader,DomainRepository>();
            services.AddScoped<IPackageRepository,PackageRepository>();

            services.AddScoped<IDataSeeder,DataSeeder>();


            services.AddSingleton<IDomainService,DomainService>();
            services.AddSingleton<IEventMapper,DefaultEventMapper>();

            services.AddScoped<IQueryHandler<GetDomainModels,List<ModelDto>>,GetDomainModelsHandler>();
            services.AddScoped<IQueryHandler<GetDomain, DomainDto?>,GetDomainHandler>();
            services.AddScoped<IQueryHandler<FindModelById, ModelDto?>,FindModelByIdHandler>();
            services.AddScoped<IQueryHandler<GetModels,List<ModelDto>>,GetModelsHandler>();
            services.AddScoped<IQueryHandler<GetProblemDomainModels,List<ModelDto>>,GetProblemDomainModelsHandler>();
            services.AddScoped<IQueryHandler<FindModels,List<ModelDto>>,FindModelsHandler>();
            services.AddScoped<IQueryHandler<GetPackage,PackageDto?>,GetPackageHandler>();
            services.AddScoped<IQueryHandler<ListPackages, List<PackageDto>>,ListPackagesHandler>();
            services.AddScoped<IQueryHandler<FindDomainModelById, DomainModelDto?>,FindDomainModelByIdHandler>();
            services.AddScoped<IQueryHandler<FindDomainModelsById,List<DomainModelDto>?>,FindDomainModelsByIdHandler>();

            // services.AddScoped<IQueryHandler<GetModelsByName, IList<ModelDto>>,GetModelsByNameHandler>();
            // services.AddScoped<IQueryHandler<GetModelsAtSpecificLevel, IList<ModelDto>>,GetModelsAtSpecificLevelHandler>();

            services.AddScoped<ICommandHandler<CreateModel>,CreateModelHandler>();
            services.AddScoped<ICommandHandler<DeleteModel>,DeleteModelHandler>();
            services.AddScoped<ICommandHandler<CreatePackage>,CreatePackageHandler>();
            services.AddScoped<ICommandHandler<CreatePackageFromDomain>,CreatePackageFromDomainHandler>();
            services.AddScoped<ICommandHandler<CreateModelsFromPackage>,CreateModelsFromPackageHandler>();
            services.AddScoped<ICommandHandler<DeletePackage>,DeletePackageHandler>();

            services.AddScoped<IEventHandler<ProblemDomainDecomposed>,ProblemDomainDecomposedHandler>();
            services.AddScoped<IEventHandler<ProblemDomainRemoved>,ProblemDomainRemovedHandler>();
            services.AddScoped<IEventHandler<SubDomainRemoved>,SubDomainRemovedHandler>();


            return services;
        }
    }
}