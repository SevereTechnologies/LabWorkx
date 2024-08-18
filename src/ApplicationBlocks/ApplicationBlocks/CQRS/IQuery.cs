using MediatR;

namespace ApplicationBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{
}
