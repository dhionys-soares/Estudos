using CleanArch.Domain.Accounts.ValueObjects.Exceptions;

namespace CleanArch.Domain.Shared.ValueObjects;

public sealed record Name : ValueObject

{
    #region Constants

    public const int  MaxLength = 60;
    public const int  MinLength = 3;

    #endregion
    
    #region Constructors

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    #endregion

    #region Factories

    public static Name Create(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new InvalidNameException("First name cannot be empty");
        
        if (string.IsNullOrWhiteSpace(lastName))
            throw new InvalidNameException("Last name cannot be empty");
        
        if (firstName.Length < Name.MinLength)
            throw new Exception("First name cannot be empty");
        
        if (firstName.Length > Name.MaxLength)
            throw new Exception("First name cannot be empty");
        
        if (lastName.Length < Name.MinLength)
            throw new Exception("First name cannot be empty");
        
        if (lastName.Length > Name.MaxLength)
            throw new Exception("First name cannot be empty");
        
        return new Name(firstName, lastName);
    }

    #endregion

    #region Properties

    public string FirstName { get;  }
    public string LastName { get;  }

    #endregion

    #region Operators

    public static implicit operator string(Name name) => name.ToString();

    #endregion

    #region Overrides

    public override string ToString() => $"{FirstName} {LastName}";

    #endregion
}