using Domain.Shared;

namespace Domain.Errors;

public static class PersistenceErrors
{
    public static Error UnableToCompleteTransaction =>
        new("Persistence.UnableToCompleteTransaction", "لم يتم تنفيذ العملية، حدثت مشكلة عند الاتصال مع قاعدة البيانات");

    public static Error UnableToCreate =>
        new("Persistence.UnableToCreate", "فشلت عملية الإضافة");

    public static Error UnableToUpdate =>
        new("Persistence.UnableToUpdate", "فشلت عملية التعديل");

    public static Error UnableToDelete =>
        new("Persistence.UnableToDelete", "فشلت عملية الحذف");

    public static Error NotFound =>
        new("Persistence.NotFound", "الغرض المطلوب غير موجود");

    public static Error Unknown =>
        new("Persistence.Unknown", "حدثت مشكلة عند الاتصال مع قاعدة البيانات");
}
