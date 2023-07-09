using Domain.Models;
using Infrastructure.Data;
using Infrastructure.IRepsository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRPresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<HRAppDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

            builder.Services.AddScoped<IDepartmentrep, Departmentrep>();

            builder.Services.AddScoped<IEmployeePersonalDataRepository, EmployeePersonalDataRepository>();
            builder.Services.AddScoped<IGenral, Genral>();
            builder.Services.AddScoped<IOfficialVacationsRepository, OfficialVacationsRepository>();
            builder.Services.AddScoped<IHoursRepository, HoursRepository>();
            builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();

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