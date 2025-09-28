using CleanStore.Application.SharedContext.Results;
using MediatR;

namespace CleanStore.Application.SharedContext.UseCases.Abstractions;

public interface IQuery<TRresponse> : IRequest<Result<TRresponse>> where TRresponse : IQueryResponse;