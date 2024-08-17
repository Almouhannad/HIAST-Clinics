using Domain.Exceptions.Base;
using Domain.Primitives;

namespace Domain.Exceptions.InvalidValue;

public class InvalidValuesDomainException<TEntity> : DomainException
    where TEntity : Entity
{
    public InvalidValuesDomainException(string message = $"Values entered for entity {nameof(TEntity)} are invalid")
        : base(message)
    {
    }
}
