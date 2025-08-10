using JwtStore.Core.Contexts.AccountContext.Entities;
using JwtStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwtStore.Core.Contexts.AccountContext.ValueObjects;
using MediatR;

namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    private readonly IService _service;

    public Handler(IRepository repository, IService service)
    {
        _repository = repository;
        _service = service;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validação

        try
        {
            var res = Specification.Ensure(request);

            if (!res.IsValid)
                return new Response("Requisição inválida", 400, res.Notifications);
        }
        catch
        {
            return new Response("Não foi possível validar a requisição", 500);
        }
        #endregion

        #region Gerar Objetos

        Email email;
        Password password;
        User user;

        try
        {
            email =  new Email(request.Email);
            password = new Password(request.Password);
            user = new User(request.Name, email, password);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }

        #endregion

        #region Verificar se o usuário existe

        try
        {
            var exists = await _repository.AnyAsync(request.Email, cancellationToken);
            if (exists)
                return new Response("Este email já está em uso", 400);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 500);
        }

        #endregion

        #region Persiste os dados

        try
        {
await _repository.SaveAsync(user, cancellationToken);
        }
        catch
        {
            return new Response("Falha ao persistir dados", 500);
        }

        #endregion

        #region Envia email de ativação

        try
        {
await _service.SendVerificationEmailAsync(user, cancellationToken);
        }
        catch
        {
            // do nothing
        }

        #endregion
        
        return new Response("Conta criada", new Response.ResponseData(user.Id,user.Name, user.Email));
    }
}