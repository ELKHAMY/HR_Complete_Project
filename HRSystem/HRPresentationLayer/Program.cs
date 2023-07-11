using Domain.Models;
using HRPresentationLayer.Permission;
using Infrastructure.Data;
using Infrastructure.IRepsository;
using Infrastructure.SeedData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRPresentationLayer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });
            // access denied
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/Denied";
            });
            builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<HRAppDbContext>();
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            builder.Services.AddScoped<IDepartmentrep, Departmentrep>();

            builder.Services.AddScoped<IEmployeePersonalDataRepository, EmployeePersonalDataRepository>();
            builder.Services.AddScoped<IGenral, Genral>();
            builder.Services.AddScoped<IOfficialVacationsRepository, OfficialVacationsRepository>();
            builder.Services.AddScoped<IHoursRepository, HoursRepository>();


            builder.Services.AddDbContext<HRAppDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await DefaultRole.SeedAsync(roleManager);
                await DefaultUser.SeedSuperAdminAsync(userManager, roleManager);
                await DefaultUser.SeedBasicAsync(userManager, roleManager);
            }
            catch (Exception)
            {
                throw;
            }

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
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}