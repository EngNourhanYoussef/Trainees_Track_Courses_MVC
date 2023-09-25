using System.ComponentModel.DataAnnotations;

namespace Trainees_Track_Courses_MVC.View_Model
{
    public class LoginVM
    {
       
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public bool RemeberMe { get; set; }
        
    }
}
