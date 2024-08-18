using Domain.Shared.Validation;
using Domain.Shared;
using MediatR;
using FluentValidation;

namespace Application.Behaviors;

// Using MediatR pipeline to perform validation
// Using Fluent validation (IValidator) to make validators
public class ValidationPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> // From MediatR
    where TRequest : IRequest<TResponse> // Request sent by the pipeline (enforced by imp. of CQRS)
    where TResponse : Result // Type of response (enforced by imp. of CQRS)
{

    #region CTOR DI for validators
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    #endregion


    #region Create validation result
    private static TResult CreateValidationResult<TResult>(Error[] errors)
        where TResult : Result
    {
        // Simple case, Result only
        if (typeof(TResult) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
            // This won't fail ever
        }

        // Other complicated case, we have a Result<Type>
        // Using reflection 
        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
            .GetMethod(nameof(ValidationResult.WithErrors))!
            .Invoke(null, [errors])!;

        return (TResult)validationResult;
    }

    #endregion

    #region Handle method (pipeline behavior)
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)

    {
        // Validate request
        // If any errors, return validation request
        // Otherwise,return next() [Pipline ~ Middleware]

        // Case of no validators
        if (!_validators.Any())
        {
            return await next();
        }

        // Generate errors array

        Error[] errors = _validators
            .Select(validator => validator.Validate(request)) // Select the result of validate method
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => new Error( // Project into Error object
                failure.PropertyName,
                failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length != 0)
        {
            return CreateValidationResult<TResponse>(errors);
            // Static method in this class
        }

        return await next();
    }
    #endregion



}
