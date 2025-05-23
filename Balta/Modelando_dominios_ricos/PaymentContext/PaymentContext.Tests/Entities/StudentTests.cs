using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("35111507795", Domain.Enums.EDocumentType.CPF);
        _email = new Email("batman@dc.com");
        _address = new Address("Rua 1", "1234", "Bairro legal", "Gotham", "SP", "BR", "13400000");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);

    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PaypalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", _document, _address, _email, "12345678");

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSucessWhenAddSubscription()
    {
            var payment = new PaypalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "WAYNE CORP", _document, _address, _email, "12345678");
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsFalse(_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}