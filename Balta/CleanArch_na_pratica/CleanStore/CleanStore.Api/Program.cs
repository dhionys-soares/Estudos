using CleanStore.Application;
using CleanStore.Application.AccountContext.UseCases.Create;
using CleanStore.Infrastructure;
using CleanStore.Infrastructure.SharedContext.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost,1433;Database=CleanStore;User=sa;Password=*$8)uoh5xZ)6HZ-;Trusted_Connection=False;TrustServerCertificate=True;";
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(connectionString,
        m => m.MigrationsAssembly("CleanStore.Api")));
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.MapPost("/v1/accounts", async (
    ISender sender,
    Command command) =>
{
var result = await sender.Send(command);
return TypedResults.Created($"v1/accounts/{result.Value.Id}", result);
});

app.Run();