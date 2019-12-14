using Abp.Application.Navigation;
using Abp.Localization;
using NEXARC.Authorization;

namespace NEXARC.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class NEXARCNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("Dashboard"),
                        url: "",
                        icon: "fa fa-chart-area",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Departments,
                        L("Employees"),
                        url: "Employees",
                        icon: "fa far fa-folder",
                        requiredPermissionName: PermissionNames.Pages_Employees
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Employees,
                            L("Masterlist"),
                            url: "Employees",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Employees
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Departments,
                            L("EmployeeMovements"),
                            url: "EmployeeMovements",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Employees
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Departments,
                            L("Accountabilities"),
                            url: "Accountabilities",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Employees
                        )
                    )

                    .AddItem(
                        new MenuItemDefinition(
                            PageNames.Departments,
                            L("Offences"),
                            url: "Offences",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Employees
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Departments,
                            L("InactiveEmployees"),
                            url: "InactiveEmployees",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Employees
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("Maintenance"),
                        url: "Maintenance",
                        icon: "fa-info-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Departments,
                            L("Departments"),
                            url: "Departments",
                            icon: "fa fa-object-group",
                            requiredPermissionName: PermissionNames.Pages_Departments
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Teams"),
                            url: "Teams",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Designations"),
                            url: "Designations",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Division"),
                            url: "Divisions",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Ranks"),
                            url: "Ranks",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Sections"),
                            url: "Sections",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("EmploymentTypes"),
                            url: "EmploymentTypes",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Sites"),
                            url: "Sites",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("CostCenters"),
                            url: "CostCenters",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Offenses"),
                            url: "Offenses",
                            icon: "fa-info-circle"
                        )
                    )
                )

                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("Security"),
                        url: "Security",
                        icon: "fa-info-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Tenants,
                            L("Tenants"),
                            url: "Tenants",
                            icon: "fa fa-building",
                            requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "Users",
                            icon: "fa fa-users",
                            requiredPermissionName: PermissionNames.Pages_Users
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Roles,
                            L("Roles"),
                            url: "Roles",
                            icon: "fa fa-user-cog",
                            requiredPermissionName: PermissionNames.Pages_Roles
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("Supplimentary"),
                        url: "Supplimentary",
                        icon: "fa-info-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Barangay"),
                            url: "Barangay",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("City"),
                            url: "City",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Municipality"),
                            url: "Minucipality",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Province"),
                            url: "Province",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Regions"),
                            url: "Regions",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("BloodTypes"),
                            url: "BloodTypes",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Nationalities"),
                            url: "Nationalities",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Certificates"),
                            url: "Certificates",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("EducationalAwards"),
                            url: "EducationalAwards",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Holidays"),
                            url: "Holidays",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Religions"),
                            url: "Religions",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("Schools"),
                            url: "Schools",
                            icon: "fa-info-circle"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("LeaveManagement"),
                        url: "LeaveManagement",
                        icon: "fa-info-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("LeaveTypes"),
                            url: "LeaveTypes",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("LeaveSetup"),
                            url: "LeaveSetup",
                            icon: "fa-info-circle"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("LeaveAdjustment"),
                            url: "LeaveAdjustment",
                            icon: "fa-info-circle"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("SelfService"),
                        url: "SelfService",
                        icon: "fa-info-circle"
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.About,
                            L("ApproverSetup"),
                            url: "ApproverSetup",
                            icon: "fa-info-circle"
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("ResumeBank"),
                        url: "ResumeBank",
                        icon: "fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("CompanyPolicy"),
                        url: "CompanyPolicy",
                        icon: "fa-info-circle"
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("EmployeeHandbook"),
                        url: "EmployeeHandbook",
                        icon: "fa-info-circle"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NEXARCConsts.LocalizationSourceName);
        }
    }
}
