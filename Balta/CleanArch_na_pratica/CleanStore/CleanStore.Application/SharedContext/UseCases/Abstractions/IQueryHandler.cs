using CleanStore.Application.SharedContext.Results;
using MediatR;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;

public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, Result> where TQuery : ICommand;

    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : ICommand<TResponse>
        where TResponse : IQueryResponse, ICommandResponse
    {
    }