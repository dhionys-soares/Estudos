using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Comands;

namespace PaymentContext.Domain.Comands
{
    public class CreateBoletoSubscriptionComand : Notifiable<Notification>, IComand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
    public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerEmail { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "O nome deve conter no mínimo, 3 caracteres")
            .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "O sobrenome deve conter no mínimo, 3 caracteres")
            .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "O nome deve conter no máximo, 40 caracteres")
            );
        }
    }
}