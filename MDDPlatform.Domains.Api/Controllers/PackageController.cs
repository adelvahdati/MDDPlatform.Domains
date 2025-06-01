using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Services.Commands;
using MDDPlatform.Messages.Dispatchers;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.Domains.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class PackageController : ControllerBase
{
    private readonly IMessageDispatcher _messageDispatcher;

    public PackageController(IMessageDispatcher messageDispatcher)
    {
        _messageDispatcher = messageDispatcher;
    }

    [HttpPost]
    public async Task CreatePackage(CreatePackage command)
    {
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("Domain/{domainId}/{title}")]
    public async Task CreatePackageFromDomain(Guid domainId,string title)
    {
        CreatePackageFromDomain command = new CreatePackageFromDomain(title,domainId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpPost("{packageId}/Domain/{domainId}")]
    public async Task CreateModelsFromPackage(Guid packageId, Guid domainId){
        CreateModelsFromPackage command = new(domainId,packageId);
        await _messageDispatcher.HandleAsync(command);
    }
    [HttpGet("{packageId}")]
    public async Task<PackageDto?> GetPackage(Guid packageId)
    {
        var query = new GetPackage(packageId);
        return await _messageDispatcher.HandleAsync<PackageDto?>(query);
    }
    [HttpGet]
    public async Task<List<PackageDto>> ListPackages(){
        var query = new ListPackages();
        return await _messageDispatcher.HandleAsync<List<PackageDto>>(query);
    }
    [HttpDelete("{packageId}")]
    public async Task DeletePackage(Guid packageId){
        var cmd = new DeletePackage(packageId);
        await _messageDispatcher.HandleAsync(cmd);
    }
}