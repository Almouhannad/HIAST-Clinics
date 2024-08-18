using Domain.Shared;
using MediatR;

namespace Application.Abstractions.CQRS.Commands;

// No response
public interface ICommand : IRequest<Result>
{
}

// With response
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
