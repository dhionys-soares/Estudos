namespace JwtStore.Core.Contexts.AccountContext.UseCases.Create;

public class Request
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}