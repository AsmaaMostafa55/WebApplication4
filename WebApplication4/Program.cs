using CompanyData.Contexts;
using CompanyData.Entities;
using CompanyRepository.interfaces;
using CompanyRepository.Repositries;
using CompanyServices.Interfaces;
using CompanyServices.Interfaces.Department.Dto;
using CompanyServices.Mapping;
using CompanyServices.Mapping.Departments;
using CompanyServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddIdentity<ApplicationUsercs, IdentityRole>(config =>
            {
                config.Password.RequiredUniqueChars = 2;

                config.Password.RequireDigit = true;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
                config.Password.RequireNonAlphanumeric=true;
                config.User.RequireUniqueEmail = true;
                config.Lockout.AllowedForNewUsers = true;
                config.Lockout.MaxFailedAccessAttempts = 3;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);

            } ).AddEntityFrameworkStores<CompanyDbContexts>()
            .AddDefaultTokenProviders();


            builder.Services.ConfigureApplicationCookie(Options => { 
            Options.Cookie.HttpOnly = true;
                Options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                Options.SlidingExpiration = true;
                Options.LoginPath = "/Account/Login";
                Options.LogoutPath = "Account/Logout";
                Options.AccessDeniedPath = "Account/AccessDEnied";
                Options.Cookie.Name= "admin";
                Options.Cookie.SecurePolicy= CookieSecurePolicy.Always;
                Options.Cookie.SameSite = SameSiteMode.Strict;
            });

            var app=builder.Build();
          //  builder.Services.AddScoped<IDepartmentRepositry,DepartmentRepositry>();
          builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder .Services.AddScoped<IDepartmentService,DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));
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
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=SignUp}");

            app.Run();
        }
    }
}
