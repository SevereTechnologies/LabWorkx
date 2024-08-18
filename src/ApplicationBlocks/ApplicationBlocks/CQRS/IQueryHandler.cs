using MediatR;

namespace ApplicationBlocks.CQRS;

// query should always return response
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}
