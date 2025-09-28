using CleanStore.Domain.AggregateRoots.Abstractions;

namespace CleanStore.Application.SharedContext.Repositories.Abstractions;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot;