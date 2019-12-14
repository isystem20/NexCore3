using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace NEXARC.Authorization
{
    public class NEXARCAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);


            //Employees
            context.CreatePermission(PermissionNames.Pages_Employees, L("HR.Employees"))
                .CreateChildPermission("HR.Employee.Create", L("HR.Create.Employee"))
                .CreateChildPermission("HR.Employee.Read", L("HR.Read.Employee"))
                .CreateChildPermission("HR.Employee.Update", L("HR.Update.Employee"))
                .CreateChildPermission("HR.Employee.Delete", L("HR.Delete.Employee"));


            context.CreatePermission(PermissionNames.Pages_Departments, L("HR.Department"))
                .CreateChildPermission("HR.Department.Create", L("HR.Create.Department"))
                .CreateChildPermission("HR.Department.Read", L("HR.Read.Department"))
                .CreateChildPermission("HR.Department.Update", L("HR.Update.Department"))
                .CreateChildPermission("HR.Department.Delete", L("HR.Delete.Department"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NEXARCConsts.LocalizationSourceName);
        }
    }
}
