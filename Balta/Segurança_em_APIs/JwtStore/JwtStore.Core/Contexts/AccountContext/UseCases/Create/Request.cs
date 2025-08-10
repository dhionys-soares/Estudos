using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public record Request : IRequest<Response>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}