namespace Domain.Shared.Validation;

public class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors)
    : base(false, IValidationResult.ValidationError) =>
    Errors = errors;

    #region Properties
    public Error[] Errors { get; }

    #endregion

    #region Static factory
    public static ValidationResult WithErrors(Error[] errors) => new(errors);
    #endregion

}
