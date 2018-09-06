using System.Reflection;

namespace Naitzel.Intranet.Application.AdminLte
{
    public static class Setup
    {
        public static Assembly[] Assemblys => new Assembly[]
        {
            typeof(Setup).Assembly,
            typeof(Infra.Security.AdminLte.SetupSecurity).Assembly,
        };
    }
}