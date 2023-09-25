using System.ComponentModel.DataAnnotations;

namespace Trainees_Track_Courses_MVC.View_Model
{
    public class RoleVM
    {
        [Key]
        public int id { get; set; }
        public string roleName { get; set; }
    }
}
