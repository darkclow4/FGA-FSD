using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Contexts
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options) { }

        //Register model to context
        public DbSet<University> Universities { get; set;}
        public DbSet<Education> Educations { get; set;}
        public DbSet<Profiling> Profilings { get; set;}
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Account> Accounts { get; set;}
        public DbSet<AccountRole> AccountRoles { get; set;}
        public DbSet<Role> Roles { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relation between University and Education
            modelBuilder.Entity<University>()
                .HasMany(e => e.Educations)
                .WithOne(u => u.University)
                .HasForeignKey(e => e.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profiling>()
                .HasOne(e => e.Education)
                .WithOne(p => p.Profiling)
                .HasForeignKey<Profiling>(p => p.EducationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Profiling>()
                .HasOne(e => e.Employee)
                .WithOne(p => p.Profiling)
                .HasForeignKey<Profiling>(p => p.EmployeeNik)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasOne(e => e.Employee)
                .WithOne(a => a.Account)
                .HasForeignKey<Account>(a => a.EmployeeNik)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.AccountRoles)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountNik)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.AccountRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
