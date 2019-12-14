using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using NEXARC.Authorization.Roles;
using NEXARC.Authorization.Users;
using NEXARC.MultiTenancy;
using NEXARC.Domain.Entities.HR;
using NEXARC.Domain.Entities.HumanResource;

namespace NEXARC.EntityFrameworkCore
{
    public class NEXARCDbContext : AbpZeroDbContext<Tenant, Role, User, NEXARCDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Barangay> Barangays { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeState> EmployeeStates { get; set; }
        public DbSet<EmployeeEducationalBackGround> EmployeeEducationalBackGrounds { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Site> Sites { get; set; }
        public NEXARCDbContext(DbContextOptions<NEXARCDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<EmployeeState>()
        //        .HasRequired(r => r.Wine)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);


        //        //.HasOne(b => b.Site)
        //        //.WithMany()
        //        //.IsRequired()
        //        //.WillCascadeOnDelete(false);
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.c.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();
        //}
    }
}
