namespace Domain.ValidationConstants.ErrorMessages;

public static class ValidationErrorMessages
{
    public static string Required
        => "هذا الحقل مطلوب";

    public static string ArabicOrEnglishLettersOnly
        => "يجب أن يحوي هذا الحقل على أحرف عربية فقط أو أحرف انكليزية فقط ولا يحوي أي رموز أو أرقام";

    public static string ArabicLettersOnly
        => "يجب أن يحوي هذا الحقل على أحرف عربية فقط ولا يحوي أي رموز أو أرقام";

    public static string FixedLength
        => "هذا الحقل طويل للغاية";

    public static string NumbersOnly
        => "يجب أن يحوي هذا الحقل على أرقام فقط";
}
