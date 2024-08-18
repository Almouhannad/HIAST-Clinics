using Domain.Shared;

namespace Domain.Errors;

public static class PersistenceErrors
{
    public static Error UnableToCompleteTransaction =>
        new("Persistence.UnableToCompleteTransaction", "حدثت مشكلة عند الاتصال مع قاعدة البيانات");
}
