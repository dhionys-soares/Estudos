using Flunt.Notifications;
using PaymentContext.Domain.Comands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Comands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionComand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }
        public IComandResult Handle(CreateBoletoSubscriptionComand command)
        {
            // fail fast validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new ComandResult(false, "Não foi possível realizar sua assinatura");
            }

            // verificar se doc está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");
            
            // verificar se email está cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");
            
            //gerar os vo's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // gerar entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.TotalPaid, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            // relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //agrupar as validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //checar as notificações
            if (!IsValid)
            return new ComandResult(false, "Não foi possível realizar sua assinatura");
            
            //salvar as informações
            _repository.CreateSubscription(student);
            
            //enviar email de boas vindas
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada");
            
            //retornar informações
            return new ComandResult(true, "Assinatura realizada com sucesso");
        }
    }
}