namespace Domain.ValidationConstants.RegularExpressions;

public static class ValidationRegularExpressions
{
    public static string ArabicOrEnglishLettersOnly
        => @"^[\u0600-\u06ff\s]+$|^[a-zA-Z\s]+$";

    public static string ArabicLettersOnly
            => @"^[א-׿ء-ي\s]+$";

    public static string EmailAddress
        => @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public static string NumbersOnly
        => @"^\d+$";


}
