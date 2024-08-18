using Domain.ValidationConstants.ErrorMessages;
using Domain.ValidationConstants.RegularExpressions;
using FluentValidation;

namespace Application.Employees.Commands.Create;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        #region First name
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.Required);
        RuleFor(c => c.FirstName)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.FixedLength);
        RuleFor(c => c.FirstName)
            .Matches(ValidationRegularExpressions.ArabicLettersOnly)
            .WithMessage(ValidationErrorMessages.ArabicLettersOnly);
        #endregion

        #region Middle name
        RuleFor(c => c.MiddleName)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.Required);
        RuleFor(c => c.MiddleName)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.FixedLength);
        RuleFor(c => c.MiddleName)
            .Matches(ValidationRegularExpressions.ArabicLettersOnly)
            .WithMessage(ValidationErrorMessages.ArabicLettersOnly);
        #endregion

        #region Last name
        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.Required);
        RuleFor(c => c.LastName)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.FixedLength);
        RuleFor(c => c.LastName)
            .Matches(ValidationRegularExpressions.ArabicLettersOnly)
            .WithMessage(ValidationErrorMessages.ArabicLettersOnly);
        #endregion

        #region Serial number
        RuleFor(c => c.SerialNumber)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.Required);
        RuleFor(c => c.SerialNumber)
            .Matches(ValidationRegularExpressions.NumbersOnly)
            .WithMessage(ValidationErrorMessages.NumbersOnly);
        RuleFor(c => c.SerialNumber)
            .MaximumLength(20)
            .WithMessage(ValidationErrorMessages.FixedLength);
        #endregion

        #region Center status
        RuleFor(c => c.CenterStatus)
            .NotEmpty()
            .WithMessage(ValidationErrorMessages.Required);
        RuleFor(c => c.CenterStatus)
            .Matches(ValidationRegularExpressions.ArabicLettersOnly)
            .WithMessage(ValidationErrorMessages.ArabicLettersOnly);
        RuleFor(c => c.CenterStatus)
            .MaximumLength(50)
            .WithMessage(ValidationErrorMessages.FixedLength);
        #endregion

        // TODO: add validation rules for additional fields
    }
}
