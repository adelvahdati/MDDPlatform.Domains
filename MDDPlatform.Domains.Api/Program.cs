using MDDPlatform.Domains.Api.Middlewares;
using MDDPlatform.Domains.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

// Add CORS
builder.Services.AddCors(options=>{
    options.AddPolicy("APIClient",policy=>{
        policy.WithOrigins("http://localhost:6094","https://localhost:7021")
                .AllowAnyHeader()
                .AllowAnyMethod();                
    });
});


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("APIClient");

app.UseAuthorization();

app.UseEndpoints(endpoint =>{
    endpoint.MapGet("/", () => {                        
        return "MDDPlatform.Domains is running";
    } );
});

app.MapControllers();

app.Run();
