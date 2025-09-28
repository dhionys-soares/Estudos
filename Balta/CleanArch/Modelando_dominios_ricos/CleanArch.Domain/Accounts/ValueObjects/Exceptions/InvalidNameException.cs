using CleanArch.Domain.Shared.ValueObjects.Exceptions;

namespace CleanArch.Domain.Accounts.ValueObjects.Exceptions;

public class InvalidNameException(string message) : DomainException(message)
{
    
}