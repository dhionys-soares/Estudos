using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "O nome deve conter no mínimo, 3 caracteres")
            .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "O sobrenome deve conter no mínimo, 3 caracteres")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "O nome deve conter no máximo, 40 caracteres")
            );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}