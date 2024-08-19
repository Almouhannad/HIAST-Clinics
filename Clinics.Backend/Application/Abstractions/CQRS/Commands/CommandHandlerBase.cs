using Domain.Errors;
using Domain.Shared;
using Domain.UnitOfWork;

namespace Application.Abstractions.CQRS.Commands;

public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    protected readonly IUnitOfWork _unitOfWork;

    protected CommandHandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(TCommand request, CancellationToken cancellationToken)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            var result = await HandleHelper(request, cancellationToken);
            if (result.IsSuccess)
            {
                transaction.Commit();
            }
            return result;
        }
        catch (Exception)
        {
            transaction.Rollback();
            return Result.Failure(PersistenceErrors.UnableToCompleteTransaction);
        }
    }

    public abstract Task<Result> HandleHelper(TCommand request, CancellationToken cancellationToken);
}


public abstract class CommandHandlerBase<TCommand, TResponse> : ICommandHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    protected readonly IUnitOfWork _unitOfWork;
    protected CommandHandlerBase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<TResponse>> Handle(TCommand request, CancellationToken cancellationToken)
    {
        using var transaction = _unitOfWork.BeginTransaction();
        try
        {
            var result = await HandleHelper(request, cancellationToken);
            if (result.IsSuccess)
            {
                transaction.Commit();
            }
            return result;
        }
        catch (Exception)
        {
            return Result.Failure<TResponse>(PersistenceErrors.UnableToCompleteTransaction);
        }
    }

    public abstract Task<Result<TResponse>> HandleHelper(TCommand request, CancellationToken cancellationToken);
}
