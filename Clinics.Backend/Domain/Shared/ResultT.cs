namespace Domain.Shared;

public class Result<TValue> : Result
{
    #region Ctor

    public Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    #endregion

    #region Properties

    private readonly TValue? _value;
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");


    #endregion

    #region Methods

    #region Static factory
    public static Result<TValue> Create(TValue? value, bool isSuccess, Error error)
    {
        try
        {
            Result.Create(isSuccess, error);
        }
        catch (Exception)
        {

            throw;
        }
        return new Result<TValue>(value, isSuccess, error);
    }
    #endregion

    #endregion

    // To allow returning a result without required castring
    public static implicit operator Result<TValue>(TValue? value) => Create(value);
}
