using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.Repository;

namespace Trainees_Track_Courses_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TraineesDBContext>(db =>
            db.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));


            builder.Services.AddScoped<ITraineesRepository, TraineesRepo>();
            builder.Services.AddScoped<ITrackRepository, TrackRepo>();
            builder.Services.AddScoped<ICourseRepository, CourseRepo>();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>( 
              ).
              AddEntityFrameworkStores<TraineesDBContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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