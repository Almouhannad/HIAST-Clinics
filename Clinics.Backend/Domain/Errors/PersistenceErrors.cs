using Domain.Shared;

namespace Domain.Errors;

public static class PersistenceErrors
{
    public static Error UnableToCompleteTransaction =>
        new("Persistence.UnableToCompleteTransaction", "حدثت مشكلة عند الاتصال مع قاعدة البيانات");

    public static Error NotFound =>
        new("Persistence.NotFound", "الغرض المطلوب غير موجود");
}
