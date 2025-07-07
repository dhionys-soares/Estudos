using System.Security.Claims;
using System.Text;
using JWTAspNet;
using JwtAspNet.Extensions;
using JWTAspNet.Models;
using JWTAspNet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<TokenService>();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.PrivateKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admin", policy => policy.RequireRole("admin"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", (TokenService service) =>
{
    var user = new User(
        1,
        "André Baltieri",
        "xyz@balta.io",
        "https://balta.io/",
        "xyxz",
        new[] { "student", "premium" });
    return service.Create(user);
});

app.MapGet("/restrito", (ClaimsPrincipal user) => new
    {
        id = user.Id(),
        name = user.Name(),
        email = user.Email(),
        giverName = user.GivenName(),
        image = user.Image()
    }).RequireAuthorization();

app.MapGet("/admin", () => "Você tem acesso").RequireAuthorization("Admin");

app.Run();
