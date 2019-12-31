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

			context.CreatePermission(PermissionNames.Pages_Cities, L("HR City"))
				.CreateChildPermission("HR.City.Create",L("HR Create City"))
				.CreateChildPermission("HR.City.Read",L("HR Read City"))
				.CreateChildPermission("HR.City.Update",L("HR Update City"))
				.CreateChildPermission("HR.City.Delete",L("HR Delete City"));

			context.CreatePermission("HR.Division",L("HR Division"))
				.CreateChildPermission("HR.Division.Create",L("HR Create Division"))
				.CreateChildPermission("HR.Division.Read",L("HR Read Division"))
				.CreateChildPermission("HR.Division.Update",L("HR Update Division"))
				.CreateChildPermission("HR.Division.Delete",L("HR Delete Division"));

			context.CreatePermission("HR.Position",L("HR Position"))
				.CreateChildPermission("HR.Position.Create",L("HR Create Position"))
				.CreateChildPermission("HR.Position.Read",L("HR Read Position"))
				.CreateChildPermission("HR.Position.Update",L("HR Update Position"))
				.CreateChildPermission("HR.Position.Delete",L("HR Delete Position"));

			context.CreatePermission("HR.Rank",L("HR Rank"))
				.CreateChildPermission("HR.Rank.Create",L("HR Create Rank"))
				.CreateChildPermission("HR.Rank.Read",L("HR Read Rank"))
				.CreateChildPermission("HR.Rank.Update",L("HR Update Rank"))
				.CreateChildPermission("HR.Rank.Delete",L("HR Delete Rank"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NEXARCConsts.LocalizationSourceName);
        }
    }
}
