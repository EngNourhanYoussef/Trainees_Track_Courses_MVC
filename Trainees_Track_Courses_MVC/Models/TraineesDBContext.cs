using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trainees_Track_Courses_MVC.View_Model;

namespace Trainees_Track_Courses_MVC.Models
{
    public class TraineesDBContext : IdentityDbContext<ApplicationUser>
    {

        public TraineesDBContext(DbContextOptions<TraineesDBContext> contextOptions):base(contextOptions) 
        
        {
            
        }

        public virtual DbSet<Trainees> Trainee { get; set; }
        public virtual DbSet<Tracks> Track { get; set; }
        public virtual DbSet<Courses> Course { get; set; }
        public DbSet<Trainees_Track_Courses_MVC.View_Model.RoleVM> RoleVM { get; set; } = default!;
    }


    
}
