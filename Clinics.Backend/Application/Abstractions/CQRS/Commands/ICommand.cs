using MediatR;

namespace Application.Abstractions.CQRS.Commands;

// No response
public interface ICommand : IRequest
{
}

// With response
public interface ICommand<TResponse> : IRequest<TResponse>
{
}
