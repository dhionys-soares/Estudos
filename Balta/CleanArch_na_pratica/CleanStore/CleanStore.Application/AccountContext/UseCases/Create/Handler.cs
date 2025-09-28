using CleanStore.Application.AccountContext.Repositories.Abstractions;
using CleanStore.Application.SharedContext.Results;
using CleanStore.Application.SharedContext.UseCases.Abstractions;
using CleanStore.Domain.AccountContext.Entities;
using CleanStore.Domain.AccountContext.ValueObjects;

namespace CleanStore.Application.AccountContext.UseCases.Create;

public sealed class Handler(
    IAccountRepository accountRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        var emailExists = await accountRepository.VerifyEmailExistsAsync(request.Email);

        if (emailExists)
            return Result.Failure<Response>(new Error("400", "Email already exists"));

        // gerar os vo
        var email = Email.Create(request.Email);
        
        // gerar as entidades
        var account = Account.Create(email);
        
        // persistir os dados
        accountRepository.SaveAsync(account);
        unitOfWork.CommitAsync();
        
        // retornar a resposta
        var response = new Response(account.Id, account.Email);
        return Result.Success<Response>(response);
    }
}