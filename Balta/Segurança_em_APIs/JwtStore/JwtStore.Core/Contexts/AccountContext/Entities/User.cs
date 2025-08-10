using JwtStore.Core.Contexts.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.SharedContext.Entities;

namespace JwtStore.Core.Contexts.AccountContext.Entities;

public class User : Entity
{
    protected User()
    {
    }

    public User(string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public User(string? email, string? password = null)
    {
        Email = email ?? String.Empty;
        Password = new  Password(password);
    }
    
    public string Name { get; private set; } = string.Empty;
    public Email Email { get; set; } = null!;
    public Password Password { get; private set; } = null!;
    public string Image {get; private set;} =  string.Empty;

    public void UpdatePassword(string plainTextPassword, string code)
    {
        if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
            throw new Exception("Código de restauração inválido");
        
        var passWord = new Password(plainTextPassword);
        Password = passWord;
    }

    public void UpdateEmail(Email email)
    {
        Email = email;
    }

    public void ChangePassword(string plainTextPassword)
    {
        var passWord = new Password(plainTextPassword);
        Password = passWord;
    }
}