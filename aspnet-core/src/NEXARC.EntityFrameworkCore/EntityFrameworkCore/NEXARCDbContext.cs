using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NEXARC.Authorization.Roles;
using NEXARC.Authorization.Users;
using NEXARC.MultiTenancy;

namespace NEXARC.EntityFrameworkCore
{
    public class NEXARCDbContext : AbpZeroDbContext<Tenant, Role, User, NEXARCDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public NEXARCDbContext(DbContextOptions<NEXARCDbContext> options)
            : base(options)
        {
        }
    }
}
