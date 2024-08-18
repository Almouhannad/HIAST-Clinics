namespace Domain.Shared.Validation;

public class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors)
    : base(default, false, IValidationResult.ValidationError) =>
    Errors = errors;

    #region Properties
    public Error[] Errors { get; }

    #endregion

    #region Static factory
    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
    #endregion
}
