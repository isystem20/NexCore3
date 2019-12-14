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
                        PageNames.Departments,
                        L("Employees"),
                        url: "Employees",
                        icon: "fa fa-object-group",
                        requiredPermissionName: PermissionNames.Pages_Employees
                    )
                )
                //.AddItem(
                //    new MenuItemDefinition(
                //        PageNames.Notices,
                //        L("Clients"),
                //        url: "Clients",
                //        icon: "fa-black-tie",
                //        requiredPermissionName: "Admin.Client"
                //    )
                //)

                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fa-info-circle"
                    )
                ).AddItem( // Menu items below is just for demonstration!
                    new MenuItemDefinition(
                        "MultiLevelMenu",
                        L("MultiLevelMenu"),
                        icon: "fa-share"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetBoilerplate",
                            new FixedLocalizableString("ASP.NET Boilerplate"),
                            icon: "fa-dot-circle-o"
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetboilerplate.com?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateTemplates",
                                new FixedLocalizableString("Templates"),
                                url: "https://aspnetboilerplate.com/Templates?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateSamples",
                                new FixedLocalizableString("Samples"),
                                url: "https://aspnetboilerplate.com/Samples?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetBoilerplateDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetboilerplate.com/Pages/Documents?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "AspNetZero",
                            new FixedLocalizableString("ASP.NET Zero"),
                            icon: "fa-dot-circle-o"
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroHome",
                                new FixedLocalizableString("Home"),
                                url: "https://aspnetzero.com?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDescription",
                                new FixedLocalizableString("Description"),
                                url: "https://aspnetzero.com/?ref=abptmpl#description",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFeatures",
                                new FixedLocalizableString("Features"),
                                url: "https://aspnetzero.com/?ref=abptmpl#features",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroPricing",
                                new FixedLocalizableString("Pricing"),
                                url: "https://aspnetzero.com/?ref=abptmpl#pricing",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroFaq",
                                new FixedLocalizableString("Faq"),
                                url: "https://aspnetzero.com/Faq?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        ).AddItem(
                            new MenuItemDefinition(
                                "AspNetZeroDocuments",
                                new FixedLocalizableString("Documents"),
                                url: "https://aspnetzero.com/Documents?ref=abptmpl",
                                icon: "fa-genderless"
                            )
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NEXARCConsts.LocalizationSourceName);
        }
    }
}
