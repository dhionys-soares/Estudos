using CleanArch.Domain.Shared.Entities;
using CleanArch.Domain.Shared.ValueObjects;

namespace CleanArch.Domain.Accounts.Entities;

public class Student : Entity
{
    #region Constructors

    public Student(string firstName, string lastName, string email, string password) : base(Guid.CreateVersion7())
    {
        Name = Name.Create(firstName, lastName);
        Email = email;
        Password = password;
    }

    #endregion

    public Name Name { get; }
    public string Email { get;  }
    public string Password { get;  }
}