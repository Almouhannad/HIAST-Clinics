using System.Reflection;

namespace EmployeesAPI;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
