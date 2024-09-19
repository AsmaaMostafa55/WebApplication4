using CompanyData.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;




namespace CompanyData.Contexts
{
    public class CompanyDbContexts : IdentityDbContext<ApplicationUsercs>
    {
        public CompanyDbContexts(DbContextOptions options):base (options)
        {


        }

        public CompanyDbContexts()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly. GetExecutingAssembly());

         //   modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.isdeleted);


            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("");
        //}
        public DbSet<Employee> Employees { get; set; }
public DbSet <Department> Departments { get; set; }
    }

    public class IdentityDbContext
    {
    }
}
