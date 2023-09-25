using Microsoft.AspNetCore.Identity;

namespace Trainees_Track_Courses_MVC.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string FristName { get; set; }
        public string LastName { get; set; }




    }
}
