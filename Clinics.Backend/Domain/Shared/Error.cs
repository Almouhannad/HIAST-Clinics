namespace Domain.Shared;

public class Error : IEquatable<Error>
{
    #region Ctor
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    #endregion

    #region Properties
    public string Code { get; }
    public string Message { get; }
    #endregion

    #region Methods

    #region Equality by value
    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Error? a, Error? b) => !(a == b);

    public virtual bool Equals(Error? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is Error error && Equals(error);
    #endregion

    #region Hash code
    public override int GetHashCode() => HashCode.Combine(Code, Message);
    #endregion

    public static implicit operator string(Error error) => error.Code;
    public override string ToString() => Code;
    #endregion

    #region Statics
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
    #endregion


}
