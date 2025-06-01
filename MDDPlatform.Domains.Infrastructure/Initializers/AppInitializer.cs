using MDDPlatform.Domains.Services.ExternalEvents;
using MDDPlatform.Messages.Brokers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MDDPlatform.Domains.Infrastructure.Initializers
{
    public class AppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private ILogger<AppInitializer> _logger;
        public AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
                using var scope = _serviceProvider.CreateScope();
                try{
                    IMessageBroker messageBroker = scope.ServiceProvider.GetRequiredService<IMessageBroker>();                
                    
                    await messageBroker.SubscribeAsync<ProblemDomainDecomposed>();
                    _logger.LogInformation("Subscribe to 'ProblemDomainDecomposed' Event");

                    await messageBroker.SubscribeAsync<ProblemDomainRemoved>();
                    _logger.LogInformation("Subscribe to 'ProblemDomainRemoved' Event");

                    await messageBroker.SubscribeAsync<SubDomainRemoved>();
                    _logger.LogInformation("Subscribe to 'SubDomainRemoved' Event");

                }catch(Exception ex) 
                {
                    _logger.LogInformation("Subscription to the Events failed");
                    _logger.LogError(ex.Message);
                }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Domain Service Stoped");
            return Task.CompletedTask;
        }
    }
}