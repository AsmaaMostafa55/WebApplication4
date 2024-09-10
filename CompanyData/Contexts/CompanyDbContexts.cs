using CompanyData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Contexts
{
    public class CompanyDbContexts :DbContext
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
}
