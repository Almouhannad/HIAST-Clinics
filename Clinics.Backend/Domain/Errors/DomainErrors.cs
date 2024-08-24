using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static Error InvalidValuesError =>
        new("Domain.InvalidValues", "القيم المدخلة غير صالحة");

    public static Error PatientAlreadyHasThisMedicine =>
        new("Domain.PatientAlreadyHasThisMedicine", "المريض لديه بالفعل الدواء الذي تحاول اضافته");

    public static Error PatientAlreadyHasThisDisease =>
        new("Domain.PatientAlreadyHasThisDisease", "المريض لديه بالفعل المرض الذي تحاول اضافته");

    public static Error InvalidHusbandRole =>
        new("Domain.InvalidHusbandRole", "لا يمكن للموظف أن يكون له زوج");

    public static Error InvalidWifeRole =>
        new("Domain.InvalidWifeRole", "لا يمكن للموظفة أن يكون لها زوجة");

    public static Error RelationAlreadyExist =>
        new("Domain.RelationAlreadyExist", "العلاقة موجودة بالفعل");

    public static Error PhoneAlreadyExist =>
        new("Domain.PhoneAlreadyExist", "رقم الهاتف موجود بالفعل");

    public static Error EmployeeAlreadyExist =>
        new("Domain.EmployeeAlreadyExist", "الموظف موجود بالفعل");

    public static Error VisitAlreadyHasThisMedicine =>
        new("Domain.VisitAlreadyHasThisMedicine", "تحتوي الوصفة الطبية بالفعل على الدواء الذي تحاول اضافته");

    public static Error VisitAlreadyHasThisMedicalTest =>
        new("Domain.VisitAlreadyHasThisMedicalTest", "تحتوي هذه الزيارة بالفعل على التحليل الطبي الذي تحاول اضافته");

    public static Error VisitAlreadyHasThisMedicalImage =>
        new("Domain.PatientAlreadyHasThisMedicine", "تحتوي هذه الزيارة بالفعل على الصورة التي تحاول اضافتها");

    public static Error InvalidHolidayDuration =>
        new("Domain.InvalidHolidayDuration", "الحد الأقصى للإجازة المرضية هو خمس أيام");

}
