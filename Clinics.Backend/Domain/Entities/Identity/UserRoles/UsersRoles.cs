namespace Domain.Entities.Identity.UserRoles;

public static class UsersRoles
{
    #region Constant values
    public static int Count => 3;
    public const string AdminName = "admin";
    public const string DoctorName = "doctor";
    public const string ReceptionistName = "receptionist";

    private static readonly UserRole _admin = UserRole.Create(1, AdminName);
    public static UserRole Admin => _admin;

    private static readonly UserRole _doctor = UserRole.Create(2, DoctorName);
    public static UserRole Doctor => _doctor;

    private static readonly UserRole _receptionist = UserRole.Create(3, ReceptionistName);
    public static UserRole Receptionist => _receptionist;

    public static List<UserRole> GetAll()
    {
        List<UserRole> roles = new();
        roles.Add(Admin);
        roles.Add(Doctor);
        roles.Add(Receptionist);
        return roles;
    }
    #endregion

}
