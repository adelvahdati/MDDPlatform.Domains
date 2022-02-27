using System.Reflection;
using MDDPlatform.Domains.Api;
using MDDPlatform.Domains.Infrastructure;
using MDDPlatform.Messages.Commands;
using MDDPlatform.Messages.Events;
using MDDPlatform.Messages.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoint =>{
    endpoint.MapGet("/", () => {                        
        return "MDDPlatform.Domains is running";
    } );
});

app.UseAuthorization();

app.MapControllers();

app.Run();
