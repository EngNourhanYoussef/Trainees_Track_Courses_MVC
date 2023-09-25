using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace Trainees_Track_Courses_MVC.Models
{
    public class Trainees
    {
        

        [Key]
        public int TrnID { get; set; }

        [Required(ErrorMessage = "Please Enter Trainee Name !")]
        [MaxLength(30, ErrorMessage = "Too long Name char!")]
        [Display(Name = "Trainees_Name")]
        public string TrnName { get; set; }


        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [EnumDataType(typeof(Gender))]
        public Gender gender { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [ForeignKey("courses")]
        public int CourseID { get; set; }

        public virtual Courses? courses { get; set; }


        [ForeignKey("tracks")]
        public int TrackID { get; set; }

        public virtual Tracks? tracks { get; set; }
    }

    
}

public enum Gender
{
    Male , Female 
}
