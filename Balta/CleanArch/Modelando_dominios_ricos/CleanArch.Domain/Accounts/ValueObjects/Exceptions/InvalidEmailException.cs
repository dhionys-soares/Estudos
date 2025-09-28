using CleanArch.Domain.Shared.ValueObjects.Exceptions;

namespace CleanArch.Domain.Accounts.ValueObjects.Exceptions;

public sealed class InvalidEmailException(string message) : DomainException(message)
{
    
}