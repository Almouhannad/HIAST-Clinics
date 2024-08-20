namespace Domain.Entities.Identity.UserRoles;

public static class Roles
{
    #region Constant values
    public static int Count => 3;
    public static Role Admin => Role.Create(1, "admin");
    public static Role Doctor => Role.Create(2, "doctor");
    public static Role Receptionist => Role.Create(3, "receptionist");

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
