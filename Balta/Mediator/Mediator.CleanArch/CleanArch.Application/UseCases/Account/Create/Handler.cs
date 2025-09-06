using Mediator.Dhionys;

namespace CleanArch.Application.UseCases.Account.Create;

public class Handler : IHandler<Command, Response>
{
    public Task<Response> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}