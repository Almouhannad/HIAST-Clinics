using Domain.Exceptions.Base;
using Domain.Primitives;

namespace Domain.Exceptions.InvalidValue;

public class InvalidValueDomainException<TEntity> : DomainException
    where TEntity : Entity
{
    private InvalidValueDomainException(string message = $"Values entered for entity {nameof(TEntity)} are invalid")
        : base(message)
    {
    }
}
