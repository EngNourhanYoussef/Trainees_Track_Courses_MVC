using System.ComponentModel.DataAnnotations;

namespace Trainees_Track_Courses_MVC.Models
{
    public class Tracks
    {
        //- ID
        //- Name
        //- Description

        [Key]
        public int TrcID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Trainees> trainees1 { get; set; }


    }
}
