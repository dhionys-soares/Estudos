using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Dima.Api.Handlers.Categories;
using Dima.Api.Handlers.Transactions;
using Dima.Api.Models;
using Dima.core.Handlers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x => x.CustomSchemaIds(n => n.FullName)); // full qualifed name

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    x => x.UseSqlServer(connectionString));
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<long>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();
builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapEndpoints();
app.MapGroup("v1/identity").WithTags("Identity").MapIdentityApi<User>();

app.MapGroup("v1/identity").WithTags("Identity").MapPost("/logout", async (SignInManager<User> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization();

app.MapGroup("v1/identity").WithTags("Identity").MapGet("/roles", (ClaimsPrincipal user) =>
{
    if (user.Identity is null || !user.Identity.IsAuthenticated)
        return Results.Unauthorized();

    var identity = user.Identity as ClaimsIdentity;
    var roles = identity?.FindAll(identity.RoleClaimType).Select(x => new
    {
        x.Issuer,
        x.OriginalIssuer,
        x.Type,
        x.Value,
        x.ValueType
    });

    return TypedResults.Json(roles);
}).RequireAuthorization();

app.Run();
