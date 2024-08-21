using Domain.Shared;

namespace Domain.Errors;

public static class IdentityErrors
{
    public static Error InvalidRole => new("Identity.InvalidRole", "Role specified for user is invalid");
    public static Error NotFound => new("Identity.NotFound", "المستخدم غير مسجّل في النظام");
    public static Error PasswordMismatch => new("Identity.PasswordMismatch", "كلمة السر غير صحيحة");
}
