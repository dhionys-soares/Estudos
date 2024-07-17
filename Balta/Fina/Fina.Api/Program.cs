using Fina.Api;
using Fina.Api.Common;
using Fina.Api.Data;
using Fina.Api.EndPoints;
using Fina.Api.Handlers;
using Fina.Core.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}
app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndPoints();

app.Run();
