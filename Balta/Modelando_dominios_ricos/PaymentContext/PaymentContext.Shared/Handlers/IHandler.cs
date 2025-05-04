using PaymentContext.Shared.Comands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : IComand
    {
        IComandResult Handle(T command);
    }
}