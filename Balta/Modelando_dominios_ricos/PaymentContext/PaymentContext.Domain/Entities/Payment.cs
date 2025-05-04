using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract<Notification>()
            .Requires()
            .IsLowerOrEqualsThan(0, total, "Payment.Total", "O valor do pagamento deve ser maior que 0")
            .IsGreaterOrEqualsThan(total, totalPaid, "Payment.TotalPaid", "O valor pago é menor que o pagamento")
            );
        }

        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public Document Document { get; set; }
        public Address Address { get; set; }
        public Email Email { get; set; }
    }
}