using CompanyData.Contexts;
using CompanyRepository.interfaces;
using CompanyRepository.Repositries;
using CompanyServices.Interfaces;
using CompanyServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace WebApplication4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDbContexts>(Options =>
            {
              Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
          //  builder.Services.AddScoped<IDepartmentRepositry,DepartmentRepositry>();
          builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder .Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
