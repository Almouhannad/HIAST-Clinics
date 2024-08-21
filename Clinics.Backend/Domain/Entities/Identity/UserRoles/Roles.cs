namespace Domain.Entities.Identity.UserRoles;

public static class Roles
{
    #region Constant values
    public static int Count => 3;
    public const string AdminName = "admin";
    public const string DoctorName = "doctor";
    public const string ReceptionistName = "receptionist";

    public static Role Admin => Role.Create(1, AdminName);
    public static Role Doctor => Role.Create(2, DoctorName);
    public static Role Receptionist => Role.Create(3, ReceptionistName);

    public static List<Role> GetAll()
    {
        List<Role> roles = new();
        roles.Add(Admin);
        roles.Add(Doctor);
        roles.Add(Receptionist);
        return roles;
    }
    #endregion

}
