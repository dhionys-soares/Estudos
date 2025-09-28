using CleanArch.Domain.Shared.ValueObjects.Exceptions;

namespace CleanArch.Domain.Accounts.ValueObjects.Exceptions;

public class InvalidFirstNameLengthException(string message) : DomainException(message)
{
    
}