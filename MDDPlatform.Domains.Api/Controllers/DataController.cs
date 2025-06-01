using MDDPlatform.Domains.Infrastructure.Seeders;
using Microsoft.AspNetCore.Mvc;

namespace MDDPlatform.Domains.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly IDataSeeder _dataseeder;

    public DataController(IDataSeeder dataseeder)
    {
        _dataseeder = dataseeder;
    }

    [HttpPost("seed")]
    public async Task SeedPackage()
    {
        await _dataseeder.SeedPackageAsync();
    }
}
