using MediatR;

namespace ApplicationBlocks.CQRS;

// do not return reponse
public interface ICommand : ICommand<Unit>
{
}

// do return response
public interface ICommand<out TResponse> : IRequest<TResponse> // interface to define a contract for all command types.
{
}
