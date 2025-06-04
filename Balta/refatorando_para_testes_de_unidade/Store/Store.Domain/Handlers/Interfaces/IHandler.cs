using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Handlers.Iterfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T? command);
    }
}