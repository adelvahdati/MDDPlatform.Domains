using MDDPlatform.Domains.Infrastructure.Data.Context;
using MDDPlatform.Domains.Services.ExternalEvents;
using MDDPlatform.Messages.Brokers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MDDPlatform.Domains.Infrastructure.Initializers{
    public class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AppInitializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ReadContext>();
                try
                {
                    await context.Database.MigrateAsync(cancellationToken);
                    Console.WriteLine("---> Database Migrated");
                }catch(Exception ex){
                    Console.WriteLine("---> Migration failed");
                    Console.WriteLine(ex.Message);
                }
                try{
                    IMessageBroker messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();                
                    await messageBroker.SubscribeAsync<ProblemDomainDecomposed>();
                    Console.WriteLine("---> Subscribe to events");
                }catch(Exception ex) {
                    Console.WriteLine("---> Subscription failed");
                    Console.WriteLine(ex.Message);
                }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service Stoped");
            return Task.CompletedTask;
        }
    }
}